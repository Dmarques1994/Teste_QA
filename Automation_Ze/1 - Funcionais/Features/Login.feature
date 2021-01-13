#language:pt-BR
Funcionalidade: 03 - Login

Contexto: 
	Dado que valido o modal maior de idade

Esquema do Cenario: 03.1 - Realizar login com sucesso
	E clico em sim maior de idade
	E insiro <email> e <senha>
	Quando clico em entrar no login
	Entao valido login realizado com sucesso

	Exemplos: 
	| email                       | senha    |
	| rosa.santos+7111@gmail.com  | teste123 |
	| rosa.santos+72011@gmail.com | teste123 |
	| rosa.santos+721@gmail.com   | teste123 |

Esquema do Cenario: 03.2 - Validar mensagens de erro EMAIL login
	E clico em sim maior de idade
	Quando Preencho <email>
	Entao valido a <mensagem> de erro email

	Exemplos: 
	| email       | mensagem                             |
	|             | O campo e-mail não pode ficar vazio  |
	| teste       | Eita, esse e-mail não parece correto |
	| teste@teste | Eita, esse e-mail não parece correto |
	| 111111      | Eita, esse e-mail não parece correto |

Esquema do Cenario: 03.3 - Validar mensagens de erro SENHA login
	E clico em sim maior de idade
	Quando insiro <email> e <senha>
	Entao valido a <mensagem> de erro senha

	Exemplos: 
	| email                      | senha    | mensagem                           |
	| rosa.santos+7111@gmail.com |          | O campo senha não pode ficar vazio |
	| rosa.santos+7111@gmail.com | 1234     | Sua senha está muito pequena       |
	| rosa.santos+7111@gmail.com | teste    | Sua senha está muito pequena       |
	| rosa.santos+7111@gmail.com | teste111 | Senha inválida                     |

