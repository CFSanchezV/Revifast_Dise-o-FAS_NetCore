using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

        [TestMethod]
        public void IniciarSesion()
        {
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();

            var username = "juantopo10"; var password = "Abc123456!";

            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);

            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            var usernameLabel = firefox.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestMethod]
        public void Editardatos()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";

            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //editaTelefono
            var manageAccButton = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[1]/a")); manageAccButton.Click();

            var phoneNum = "997998993";
            var phoneField = firefox.FindElement(By.XPath("//*[@id='Input_PhoneNumber']"));
            phoneField.Clear(); phoneField.SendKeys(phoneNum);

            var updateBtn = firefox.FindElement(By.XPath("//*[@id='update-profile-button']"));
            updateBtn.Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/main/div/div/div[2]/div[1]")));

            var alertSucess = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[2]/div[1]"));
            Assert.IsTrue(alertSucess.Displayed);
        }

        [TestMethod]
        public void CrearVehiculo()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            var vehiculosBtn = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[5]/a"));
            vehiculosBtn.Click();
            var addAutoBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/p/a")); addAutoBtn.Click();

            var placaField = firefox.FindElement(By.XPath("//*[@id='Placa']"));
            var modeloField = firefox.FindElement(By.XPath("//*[@id='Modelo']"));
            var categoriaField = firefox.FindElement(By.XPath("//*[@id='Categoria']"));
            string placa = "AFS203"; string modelo = "picanto"; string categoria = "D2";
            placaField.SendKeys(placa); modeloField.SendKeys(modelo); categoriaField.SendKeys(categoria);

            //click crear
            firefox.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input")).Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Vehiculos"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Vehiculos");
        }

        [TestMethod]
        public void CrearReserva()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //reserva
            var reservasBtn = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[6]/a"));
            reservasBtn.Click();

            var placaDrDo = firefox.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = firefox.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            selectEmpresa.SelectByText("Farenet");

            //review
            var dateField = firefox.FindElement(By.XPath("//*[@id='Fecha']"));
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var createBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            createBtn.Click();

            Assert.IsTrue(firefox.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EditarReserva()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            /*reservas*/
            firefox.Navigate().GoToUrl("http://localhost:5000/Reservas");
            var EditReservaBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[1]"));
            EditReservaBtn.Click();

            var placaDrDo = firefox.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = firefox.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            //otra Empresa
            selectEmpresa.SelectByText("ReviSeguros");

            var dateField = firefox.FindElement(By.XPath("//*[@id='Fecha']"));
            //mañana
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second); date = date.AddDays(1);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var saveBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            saveBtn.Click();

            Assert.IsTrue(firefox.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EliminarReserva()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //reserva
            var DelReservaBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[3]"));
            DelReservaBtn.Click();

            var confirmDelBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/form/input[2]"));
            confirmDelBtn.Click();

            Assert.IsTrue(firefox.Url == "http://localhost:5000/Reservas");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (firefox == null) return;
            firefox.Quit();
            firefox.Dispose();
        }
    }
}