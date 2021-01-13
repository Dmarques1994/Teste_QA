using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using ZeDelivery_QA.Drivers;

namespace Automation_Ze.Pages
{
    class LoginPage: Driver
    {
        HomePage homePage = new HomePage();
        Actions actions = new Actions(driver);

        public static readonly By txtEmailLogin = By.Id("login-mail-input-email");
        public readonly By msgErroEmailLogin = By.Id("login-mail-input-email-error-message");
        public static readonly By txtSenhaLogin = By.Id("login-mail-input-password");
        public static readonly By btnBotaoEntrar = By.Id("login-mail-button-sign-in");
        public readonly By msgErroSenhaLogin = By.Id("login-mail-input-password-error-message");
        public static readonly By cardEndereco = By.Id("delivery-options-card");
        public readonly By msgGlobalSenha = By.Id("global-message-Senha inválida");

        public LoginPage PreenchoEmail(string email)
        {
            homePage.CliqueCookies();
            SendKeys(txtEmailLogin, email);
            return this;
        }
        public LoginPage PreenchoSenha(string senha)
        {
            SendKeys(txtSenhaLogin, senha);
            return this;
        }
        public LoginPage PreenchoCamposLogin(string email, string senha)
        {
            PreenchoEmail(email)
                .PreenchoSenha(senha);
            actions.SendKeys(Keys.Tab).Build().Perform();

            return this;
        }
        public LoginPage CliqueEntrarLogin()
        {
            driver.FindElement(btnBotaoEntrar).Click();

            return this;
        }
    }
}
