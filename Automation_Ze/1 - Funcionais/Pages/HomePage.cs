using NUnit.Framework;
using OpenQA.Selenium;
using ZeDelivery_QA.Drivers;
using System.Linq;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation_Ze.Pages
{
    public class HomePage: Driver
    {
        public readonly By btnHomeNao = By.Id("age-gate-button-no");
        public readonly By btnHomeSim = By.Id("age-gate-button-yes");
        public readonly By btnEntrar = By.Id("welcome-button-sign-in");
        public static readonly By btnAceitarCookies = By.XPath("//button[@title='Aceitar cookies']");
        public readonly By modalMaiorIdade = By.XPath("//img[@alt='age-gate-logo']");
        public readonly By btnVoltarModal = By.Id("age-gate-button-try-again");

        public static bool btnCookies;

        public HomePage CliqueCookies()
        {
            Thread.Sleep(200);
            btnCookies = driver.PageSource.Contains("Aceitar cookies");
            if (btnCookies == true)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(btnAceitarCookies));
                driver.FindElement(btnAceitarCookies).Click();
            }
            return this;
        }
        public HomePage CliqueEntrar()
        {
            driver.FindElement(btnEntrar).Click();

            return this;
        }
        public HomePage CliqueBotaoNao()
        {
            driver.FindElement(btnHomeNao).Click();

            return this;
        }
        public HomePage CliqueVoltarModal()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)30);
            driver.FindElement(btnVoltarModal).Click();

            return this;
        }
        public HomePage CliqueBotaoSim()
        {
            driver.FindElement(btnHomeSim).Click();

            return this;
        }
        public HomePage CliqueBotaoEntrar()
        {
            driver.FindElement(btnEntrar).Click();
            return this;
        }
        public HomePage ValidaPagMenorIdade()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            ObterURLDaPagina();
            Assert.AreEqual("https://www.ambev.com.br/sustentabilidade/consumo-responsavel/", URL);
            driver.SwitchTo().Window(driver.WindowHandles.First());
            CliqueVoltarModal();

            return this;
        }
        public HomePage ValiaPagMaiorIdade()
        {
            ObterURLDaPagina();
            Assert.AreEqual("https://www.ze.delivery/", URL);

            return this;
        }

    }
}
