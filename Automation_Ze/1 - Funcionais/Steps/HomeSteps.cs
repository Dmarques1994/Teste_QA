using ZeDelivery_QA.Drivers;
using TechTalk.SpecFlow;
using Automation_Ze.Pages;

namespace Automation_Ze.Steps
{
    public class HomeSteps: Driver
    {
        HomePage homePage = new HomePage();
        private string botoes;


        [Given(@"que valido o modal maior de idade")]
        public void DadoQueValidoOModalMaiorDeIdade()
        {
            ElementoExiste(homePage.modalMaiorIdade, true);                       
        }

        [When(@"clico no (.*)")]
        public void QuandoClicoNoNao(string botao)
        {
            botoes = botao;
            if(botao == "nao")
            {
                homePage.CliqueBotaoNao();
            }
            else
            {
                homePage.CliqueBotaoSim();
            }
        }

        [Then(@"valido a pagina atual")]
        public void EntaoValidoAPaginaAtual()
        {
            if (botoes == "nao")
            {
                homePage.ValidaPagMenorIdade();
            }
            else
            {
                homePage.ValiaPagMaiorIdade();
            }
        }
    }
}
