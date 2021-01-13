using Automation_Ze.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TechTalk.SpecFlow;
using ZeDelivery_QA.Drivers;

namespace ZeDelivery_QA.Steps
{
    public class LoginSteps: Driver
    {
        LoginPage loginPage = new LoginPage();
        CadastroPage cadastroPage = new CadastroPage();
        Actions actions = new Actions(driver);

        [Given(@"insiro (.*) e (.*)")]
        [When(@"insiro (.*) e (.*)")]
        public void InsiroE(string email, string senha)
        {
            CadastroPage.emailUsuario = email;
            loginPage.PreenchoCamposLogin(email, senha);
        }
        [When(@"clico em entrar no login")]
        public void QuandoClicoEmEntrarNoLogin()
        {
            loginPage.CliqueEntrarLogin();
        }

        [Then(@"valido login realizado com sucesso")]
        public void EntaoValidoLoginRealizadoComSucesso()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(CadastroPage.btnMenuLogado));
            ObterURLDaPagina();
            if (ElementoExiste(LoginPage.cardEndereco, true))
            {
                Assert.AreEqual("https://www.ze.delivery/produtos", URL);
            }
            else
            {
                Assert.AreEqual("https://www.ze.delivery/", URL);
            }
            wait.Until(ExpectedConditions.ElementExists(CadastroPage.btnMenuLogado));
            cadastroPage.CliqueMenuLogado();
            Thread.Sleep(3000);
            string emailLogado = driver.FindElement(CadastroPage.emailUsuarioLogado).Text;
            Assert.AreEqual(CadastroPage.emailUsuario, emailLogado);
        }

        [When(@"Preencho (.*)")]
        [Given(@"Preenhco (.*)")]
        public void DadoPreencho(string email)
        {

            loginPage.PreenchoEmail(email);
            actions.SendKeys(Keys.Tab).Build().Perform();
        }

        [Then(@"valido a (.*) de erro senha")]
        public void EntaoValidoADeErro(string mensagem)
        {
            if (mensagem == "Senha inválida")
            {
                loginPage.CliqueEntrarLogin();
                Thread.Sleep(2000);
                ElementoExiste(loginPage.msgGlobalSenha);
                string msgCaptada = driver.FindElement(loginPage.msgGlobalSenha).Text;
                Assert.AreEqual(mensagem, msgCaptada);
            }
            else
            {
                string msgCaptada = driver.FindElement(loginPage.msgErroSenhaLogin).Text;
                Assert.AreEqual(mensagem, msgCaptada);
            }

        }

        [Then(@"valido a (.*) de erro email")]
        public void EntaoValidoADeErroEmail(string mensagem)
        {
            string msgCaptada = driver.FindElement(loginPage.msgErroEmailLogin).Text;
            Assert.AreEqual(mensagem, msgCaptada);
        }



    }
}
