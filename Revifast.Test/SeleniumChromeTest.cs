using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumTest
    {
        private IWebDriver chrome;

        [TestInitialize]
        public void Initialize()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            chrome.Manage().Window.Maximize();
            chrome.Navigate().GoToUrl("http://localhost:5000");
        }

        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = chrome.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo7";
            var password = "Abc123456!";
            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = chrome.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();
            var usernameLabel = chrome.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
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
            chrome.Quit();
            chrome.Dispose();
        }
    }
}


/*
var confirmLink = chrome.FindElement(By.Id("confirm-link"));
confirmLink.Click();
var resultDiv = chrome.FindElement(By.CssSelector("div.alert.alert-success.alert-dismissible"));
var message = Regex.Replace(resultDiv.Text, @"[^\u0000-\u007F]+", string.Empty);
message = message.Replace(Environment.NewLine, string.Empty);
Assert.AreEqual("Thank you for confirming your email.", message);
*/
