using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumEdgeTest
    {
        private IWebDriver edge;
        [TestInitialize]
        public void Initialize()
        {
            edge = new EdgeDriver();
            edge.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            edge.Manage().Window.Maximize();
            edge.Navigate().GoToUrl("http://localhost:44324");
        }
        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = edge.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo7";
            var password = "Abc123456!";
            var emailField = edge.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = edge.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = edge.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();
            var usernameLabel = edge.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }
    }
}
