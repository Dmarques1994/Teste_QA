using OpenQA.Selenium;
using ZeDelivery_QA.Drivers;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation_Ze.Pages
{
    public class CadastroPage: Driver
    {
        HomePage homePage = new HomePage();

        public static readonly By btnCriarConta = By.Id("create-account-link");
        public static readonly By txtNomeSobreNome = By.Id("signup-form-input-name");
        public readonly By msgErroNome = By.Id("signup-form-input-name-error-message");
        public static readonly By txtEmail = By.Id("signup-form-input-email");
        public readonly By msgErroEmail = By.Id("signup-form-input-email-error-message");
        public static readonly By txtSenha = By.Id("signup-form-input-password");
        public readonly By msgErroSenha = By.Id("signup-form-input-password-error-message");
        public static readonly By txtCPF = By.Id("signup-form-input-document");
        public readonly By msgErroCPF = By.Id("signup-form-input-document-error-message");
        public static readonly By txtCelular = By.Id("signup-form-input-phone");
        public readonly By msgErroCelular = By.Id("signup-form-input-phone-error-message");
        public static readonly By txtIdade = By.Id("signup-form-input-age");
        public readonly By msgErroIdade = By.Id("signup-form-input-age-error-message");
        public readonly By checkTermos = By.Id("sign-up-form-input-terms");
        public readonly By checkCupons = By.Id("sign-up-form-input-marketing");
        public static readonly By btnContinuar = By.Id("signup-form-button-signup");
        public static readonly By txtCodigoSMS = By.Id("confirm-phone-input-code");
        public static readonly By txtValidarDepois = By.Id("confirm-phone-link-validate-later");
        public static readonly By btnMenuLogado = By.Id("header-user-badge");
        public static readonly By nomeUsuarioLogado = By.XPath("//div[@id='edit-profile']//ancestor::div[1]/div[3]");
        public static readonly By emailUsuarioLogado = By.XPath("//div[@id='edit-profile']//ancestor::div[1]/div[5]");
        public static readonly By btnEntrarNaConta = By.Id("signup-form-link-have-account");
        public static string nomeUsuario;
        public static string emailUsuario;

        public CadastroPage CliqueCriarConta()
        {
            homePage.CliqueCookies();
            wait.Until(ExpectedConditions.ElementToBeClickable(btnCriarConta));
            driver.FindElement(btnCriarConta).Click();

            return this;
        }
        public CadastroPage AceitaTermos(string termos)
        {
            if(termos == "SIM")                                                                                      
            {
                Thread.Sleep(2000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                Thread.Sleep(2000);
                driver.FindElement(checkTermos).Click();
            }

            return this;
        }
        public CadastroPage AceitaCupons(string cupons)
        {
            if (cupons == "SIM")
            {
                Thread.Sleep(2000);
                driver.FindElement(checkCupons).Click();
            }

            return this;
        }

        public CadastroPage PreencheCamposCadastro(string nome, string email, string senha, string cpf, string celular, string idade, string termos, string cupons)
        {
            SendKeys(txtNomeSobreNome, nome);
            SendKeys(txtEmail, email);
            SendKeys(txtSenha, senha);
            SendKeys(txtCPF, cpf);
            SendKeys(txtCelular, celular);
            SendKeys(txtIdade, idade);
            AceitaTermos(termos)
                .AceitaCupons(cupons);

            return this;
        }
        public CadastroPage CliqueContinuar()
        {
            driver.FindElement(btnContinuar).Click();

            return this;
        }
        public CadastroPage CliqueValidarMaisTarde()
        {
            driver.FindElement(txtValidarDepois).Click();

            return this;
        }
        public CadastroPage CliqueMenuLogado()
        {
            driver.FindElement(btnMenuLogado).Click();

            return this;
        }

    }
}
