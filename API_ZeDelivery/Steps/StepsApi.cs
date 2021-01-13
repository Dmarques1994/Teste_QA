using RestSharp;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using API_ZeDelivery.Pages;

namespace API_ZeDelivery.Steps
{
    [Binding]
    public class StepsApi: ApiPage
    {
        public string content;        

        APIPage apiPage = new APIPage();

        [Given(@"que realizo a requisicao cidade usando (.*)")]
        public void DadoQueRealizoARequisicaoUsandoConsolacao(string cityname)
        {
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={cityname}&appid=973e836854d3efc018fbcf6e9b638f27");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            content = (string)response.Content;
            var detalhes = JsonConvert.DeserializeObject<APIPage.Rootobject>(content);
            APIPage.statusCode = (int)response.StatusCode;
            if (APIPage.statusCode == 200)
            {
                var teste = detalhes.weather[0];
                APIPage.id = teste.id;
                APIPage.clima = teste.main;
                APIPage.descricao = teste.description;
                apiPage.LerArquivoIdClima();
            }       
 
        }

        [Given(@"que realizo a requisicao id cidade usando (.*)")]
        public void QueRealizoARequisicaoUsandoA(string cityid)
        {
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?id={cityid}&appid=973e836854d3efc018fbcf6e9b638f27");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            content = (string)response.Content;
            var detalhes = JsonConvert.DeserializeObject<APIPage.Rootobject>(content);
            APIPage.nomeCidade = detalhes.name;
            var teste = detalhes.weather[0];
            APIPage.id = teste.id;
            APIPage.clima = teste.main;
            APIPage.descricao = teste.description;

            apiPage.LerArquivoIdClima();
        }
        [Given(@"que realizo a requisicao geografica usando (.*) e (.*)")]
        public void DadoQueRealizoARequisicaoGeograficaUsandoConsolacaoE(string lat, string lon)
        {
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=973e836854d3efc018fbcf6e9b638f27");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            content = (string)response.Content;
            var detalhes = JsonConvert.DeserializeObject<APIPage.Rootobject>(content);
            APIPage.nomeCidade = detalhes.name;
            APIPage.idCidade = detalhes.id;
            var teste = detalhes.weather[0];
            APIPage.id = teste.id;
            APIPage.clima = teste.main;
            APIPage.descricao = teste.description;

            apiPage.LerArquivoIdClima();
        }

        [Then(@"valido os retornos clima (.*)")]
        public void EntaoValidoOsRetornosClima(string nomeCidades)
        {
            apiPage.ValidacaoRetornoAPICidade(nomeCidades);
        }

        [Then(@"valido os retornos clima")]
        public void EntaoValidoOsRetornosClima()
        {
            apiPage.ValidacaoRetornoAPIIDCidade();
        }

        [Then(@"valido retornos da API (.*)")]
        public void EntaoValidoRetornosDaAPI(int status)
        {
            apiPage.ValidacaoStatusAPI(status);
        }

        [Then(@"valido retornos geograficos (.*),(.*)")]
        public void EntaoValidoRetornosGeograficosVisiedo(string nomeCidades, int idCidades)
        {
            apiPage.ValidaStatusAPICoordGeografica(nomeCidades,idCidades);
        }

    }
}
