using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Revifast.Controllers;
using Revifast.Models;
using System.Threading.Tasks;

namespace Revifast.Test
{
    [TestClass]
    public class ConductoresControllerTest
    {
        ConductoresController conductorController = new ConductoresController(new DbRevifastContext());
        Conductor conductor = new Conductor
        {
            Usuario = "test@test1",
            Nombres = "Test",
            Apellidos = "Test",
            Dni = "12345678",
            Correo = "test@test",
            Celular = "912345678",
        };
        [TestMethod]
        public void CreateConductor()
        {
            //
            var result = conductorController.Create(conductor);
            result.Wait();
            var actionResult = result.Result as RedirectToActionResult;
            Assert.IsNotNull(actionResult);
        }
        [TestMethod]
        public void ReadConductor()
        {
            //
            int conductorTestId = 22;
            //
            var result = conductorController.Details(conductorTestId);
            result.Wait();
            var viewResult = result.Result as ViewResult;
            var conductorResult = viewResult.Model as Conductor;
            Assert.AreEqual(conductorTestId, conductorResult.ConductorId);
        }
        [TestMethod]
        public void UpdateConductor()
        {
            //
            conductor.ConductorId = 22;
            //
            conductor.Usuario = "test@update";
            conductor.Nombres = "TestUpdate";
            conductor.Apellidos = "TestUpdate";
            //
            var result = conductorController.Edit(conductor.ConductorId, conductor);
            result.Wait();
            var actionResult = result.Result as RedirectToActionResult;
            //
            Assert.IsNotNull(actionResult);
        }
        [TestMethod]
        public void DeleteConductor()
        {
            conductor.ConductorId = 22;
            var result = conductorController.Delete(conductor.ConductorId);
            result.Wait();
            var viewResult = result.Result as ViewResult;
            var conductorResult = viewResult.Model as Conductor;
            var resultDeleteConfirmed = conductorController.DeleteConfirmed(conductorResult.ConductorId);
            resultDeleteConfirmed.Wait();
            Assert.IsTrue(resultDeleteConfirmed.IsCompletedSuccessfully);
        }
    }
}
