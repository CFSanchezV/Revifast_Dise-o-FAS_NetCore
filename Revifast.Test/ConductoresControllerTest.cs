using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Revifast.Controllers;
using Revifast.Data;
using Revifast.Models;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Revifast.Test
{
    [TestClass]
    public class ConductoresControllerTest
    {
        private DbRevifastContext context = new DbRevifastContext();
        private ConductoresController conductorController;
        private Conductor conductor = new Conductor
        {
            Usuario = "test_user",
            Nombres = "conductor_nombre",
            Apellidos = "conductor_apellido",
            Dni = "12345678",
            Correo = "correo_conductor@test",
            Celular = "987654321"
        };

        public ConductoresControllerTest()
        {
            conductorController = new ConductoresController(context);
        }

        [TestMethod]
        public void CreateConductor()
        {
            var result = conductorController.Create(conductor);
            result.Wait();
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} - Se ha creado el conductor con Id: {conductor.ConductorId}");
            var actionResult = result.Result as RedirectToActionResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.ActionName, "Index");
        }

        [TestMethod]
        public void ReadConductor()
        {
            conductor = context.Conductor.FirstOrDefaultAsync(c => c.Usuario == conductor.Usuario).Result;
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} - Leyendo el conductor con Id: {conductor.ConductorId}");
            var result = conductorController.Details(conductor.ConductorId);
            result.Wait();
            var viewResult = result.Result as ViewResult;
            var conductorResult = viewResult.Model as Conductor;
            Assert.AreEqual(conductor.ConductorId, conductorResult.ConductorId);
        }

        [TestMethod]
        public void UpdateConductor()
        {
            conductor = context.Conductor.FirstOrDefaultAsync(c => c.Usuario == conductor.Usuario).Result;
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} - Actualizando el conductor con Id: {conductor.ConductorId}");
            conductor.Nombres = "TestUpdate";
            conductor.Apellidos = "TestUpdate";
            var result = conductorController.Edit(conductor.ConductorId, conductor);
            result.Wait();
            var actionResult = result.Result as RedirectToActionResult;
            Assert.IsNotNull(actionResult);
        }
        [TestMethod]
        public void DeleteConductor()
        {
            conductor = context.Conductor.FirstOrDefaultAsync(c => c.Usuario == conductor.Usuario).Result;
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} - Borrando el conductor con Id: {conductor.ConductorId}");
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
