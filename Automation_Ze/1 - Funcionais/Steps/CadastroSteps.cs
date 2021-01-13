using Automation_Ze.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TechTalk.SpecFlow;
using ZeDelivery_QA.Drivers;

namespace Automation_Ze.Steps
{
    public class CadastroSteps: Driver
    {
        HomePage homePage = new HomePage();
        CadastroPage cadastroPage = new CadastroPage();

        [Given(@"clico em sim maior de idade")]
        public void DadoClicoEmSimMaiorDeIdadde()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(homePage.btnHomeSim));
            homePage.CliqueBotaoSim()
                    .CliqueEntrar();
        }
        
        [Given(@"clico em criar uma conta")]
        public void DadoClicoEmCriarUmaConta()
        {
            cadastroPage.CliqueCriarConta();
        }

        [Given(@"preencho todos os dados do cadastro (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void DadoPreenchoTodosOsDadosDoCadastro(string nome, string email, string senha, string cpf, string celular, string idade, string termos, string cupons)
        {
            Thread.Sleep(200);
            ObterURLDaPagina();
            Assert.AreEqual("https://www.ze.delivery/conta/cadastrar?redirectPhysicalPath=%2F&redirectUrlAlias=%2F", URL);
            CadastroPage.nomeUsuario = nome;
            CadastroPage.emailUsuario = email;
            cadastroPage.PreencheCamposCadastro(nome, email, senha, cpf, celular, idade, termos, cupons);
        }

        [When(@"clico em continuar")]
        public void QuandoClicoEmContinuar()
        {
            cadastroPage.CliqueContinuar();
        }
        [When(@"valido a tela de confirmacao por SMS")]
        public void QuandoValidoATelaDeConfirmacaoPorSMS()
        {
            Thread.Sleep(5000);
            ObterURLDaPagina();
            Assert.AreEqual("https://www.ze.delivery/conta/confirmar-telefone", URL);
            cadastroPage.CliqueValidarMaisTarde();            
        }

        [Then(@"valido que estou na pagina logada")]
        public void EntaoValidoQueEstouNaPaginaLogada()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(CadastroPage.btnMenuLogado));
            ObterURLDaPagina();
            Assert.AreEqual("https://www.ze.delivery/", URL);        
            wait.Until(ExpectedConditions.ElementExists(CadastroPage.btnMenuLogado));
            cadastroPage.CliqueMenuLogado();
            Thread.Sleep(3000);
            string usuarioLogado = driver.FindElement(CadastroPage.nomeUsuarioLogado).Text;
            string emailLogado = driver.FindElement(CadastroPage.emailUsuarioLogado).Text;            
            Assert.AreEqual(CadastroPage.nomeUsuario, usuarioLogado);
            Assert.AreEqual(CadastroPage.emailUsuario, emailLogado);
        }

    }
}
