using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumIExplorerTest
    {
        private IWebDriver iexplorer;

        [TestInitialize]
        public void Initialize()
        {
            iexplorer = new InternetExplorerDriver();
            iexplorer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            iexplorer.Manage().Window.Maximize();
            iexplorer.Navigate().GoToUrl("http://localhost:5000");
        }

        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = iexplorer.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo12";
            var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = iexplorer.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();
            var usernameLabel = iexplorer.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (iexplorer == null) return;
            iexplorer.Quit();
            iexplorer.Dispose();
        }
    }
}
