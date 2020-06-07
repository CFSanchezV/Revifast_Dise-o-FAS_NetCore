using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumFirefoxTest
    {
        private IWebDriver firefox;

        [TestInitialize]
        public void Initialize()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            firefox.Manage().Window.Maximize();
            firefox.Navigate().GoToUrl("http://localhost:5000");
        }

        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = firefox.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo10";
            var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = firefox.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();
            var usernameLabel = firefox.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }
        /*
        [TestMethod]
        public void IngresarCuenta()
        {
        }
        */
        [TestCleanup]
        public void Cleanup()
        {
            if (firefox == null) return;
            firefox.Quit();
            firefox.Dispose();
        }
    }
}