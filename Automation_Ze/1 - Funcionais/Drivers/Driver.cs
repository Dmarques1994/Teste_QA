using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ZeDelivery_QA.Drivers
{
    [Binding]
    public class Driver
    {
        public WebDriverWait wait;
        public static IWebDriver driver;
        public static string URL;
        public string newSendKeys = "";

        public Driver()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        [BeforeScenario]
        public static IWebDriver Navegador()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.ze.delivery/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds((int)90);


            return driver;
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        public IWebElement ElementoExiste(By by)
        {
            try
            {
                IWebElement elemento = driver.FindElement(by);
                return elemento;
            }
            catch (Exception e)
            {
                throw new Exception($"Elemento nao existe na página.\n{e.Message}");
            }
        }
        public static bool ElementoExiste(By by, bool print = true)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void SendKeys(By by, string text)
        {
            try
            {
                ElementoExiste(by).SendKeys(text);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao enviar dados para elemento ({by.ToString()}).\n{e.Message}");
            }
        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
                driver = Navegador();

            return driver;
        }
        public void ObterURLDaPagina()
        {
            URL = GetDriver().Url;
        }
    }
}
