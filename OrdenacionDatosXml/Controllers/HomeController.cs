using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OrdenacionDatosXml.Models;

namespace OrdenacionDatosXml.Controllers
{
    public class HomeController : Controller
    {
        ModeloEmpleados modelo;

        public void CargarModelo()
        {
            Uri ruta = HttpContext.Request.Url;
            string uri = ruta.Scheme + "://" + ruta.Authority + "/Documentos/empleados.xml";
            modelo = new ModeloEmpleados(uri);
        }

        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            CargarModelo();

            List<Empleado> lista = modelo.GetEmpleados();
            ViewBag.Contador = lista.Count;

            return View(lista);
        }

        // POST: Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string columnaF, string columnaO, string texto, string orden, int? fecha)
        {
            CargarModelo();

            List<Empleado> lista = modelo.GetEmpleadosPost(columnaF, columnaO, texto, orden, fecha.GetValueOrDefault());
            ViewBag.Contador = lista.Count;

            return View(lista);
        }
    }
}