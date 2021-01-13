#language:pt-BR
Funcionalidade: 01 - API Teste

Esquema do Cenario: 01.1 - Validacao API por nome de cidade
	Dado que realizo a requisicao cidade usando <cityname>
	Entao valido os retornos clima

	Exemplos: 
	| cityname   |
	| consolacao | 
	| Trindade   | 

Esquema do Cenario: 01.2 - Validacao API por codigo cidade
	Dado que realizo a requisicao id cidade usando <cityid>
	Entao valido os retornos clima <nomeCidade>

	Exemplos: 
	| nomeCidade | cityid  |
	| Xarqueada  | 3384937 |
	| Xexéu      | 3384930 |
	| Viana      | 3385122 |


Esquema do Cenario: 01.3- Validacao retornos API
	Dado que realizo a requisicao cidade usando <cityname>
	Entao valido retornos da API <status>

	Exemplos: 
	| cityname   | status |
	| consolacao | 200    |
	| Trindad    | 404    |
	|            | 400    |

Esquema do Cenario: 01.4- Validacao API por coordenadas geograficas
	Dado que realizo a requisicao geografica usando <lat> e <lon>
	Entao valido retornos geograficos <nomeCidade>,<idCidade>

	Exemplos: 
	| lat        | lon        | nomeCidade | idCidade |
	| 40.674381  | -1.11077   | Visiedo    | 6361659  |
	| 41.950668  | -2.87017   | Covaleda   | 6361123  |
	| -23.548491 | -46.657909 | Consolação | 7521912  |

