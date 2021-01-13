#language:pt-BR
Funcionalidade: 02 - Cadastro

Contexto: 
	Dado que valido o modal maior de idade

Esquema do Cenario: 02.1 - Cadastro com sucesso
	E clico em sim maior de idade
	E clico em criar uma conta
	E preencho todos os dados do cadastro <nome>,<email>,<senha>,<cpf>,<celular>,<idade>,<termos>,<cupons>
	Quando clico em continuar
	E valido a tela de confirmacao por SMS
	Entao valido que estou na pagina logada

	Exemplos: 
	| nome               | email                       | senha    | cpf            | celular    | idade | termos | cupons |
	| Teste automatizado | rosa.santos+39902@gmail.com | teste123 | 343.353.710-04 | 1165205565 | 20    | SIM    | SIM    |