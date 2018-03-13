using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OrdenacionDatosXml.Models
{
    public class ModeloEmpleados
    {
        private string uri;
        XDocument documento;

        public ModeloEmpleados(string uri)
        {
            this.uri = uri;
            documento = XDocument.Load(uri);
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in documento.Descendants("empleado")
                           select new Empleado
                           {
                               IdEmpleado = int.Parse(datos.Element("idempleado").Value),
                               Nombre = datos.Element("nombre").Value,
                               Apellido = datos.Element("apellido").Value,
                               Coche = datos.Element("coche").Value,
                               Pais = datos.Element("pais").Value,
                               Telefono = datos.Element("telefono").Value,
                               FechaAlta = int.Parse(datos.Element("fechaalta").Value)
                           };
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosPost(string propiedadF, string propiedadO, string texto, string orden, int fecha)
        {
            List<Empleado> lista = GetEmpleados();
            var columnaF = typeof(Empleado).GetProperty(propiedadF);
            var columnaO = typeof(Empleado).GetProperty(propiedadO);

            if (texto != "")
            {
                lista = lista.Where(x => columnaF.GetValue(x, null).ToString() == texto).ToList();
            }
            if (orden != null)
            {
                if (orden == "ascendente")
                {
                    lista = lista.OrderBy(x => columnaO.GetValue(x, null)).ToList();
                }
                else if (orden == "descendente")
                {
                    lista = lista.OrderByDescending(x => columnaO.GetValue(x, null)).ToList();
                }
            }
            if (fecha != 0)
            {
                lista = lista.Where(x => x.FechaAlta >= fecha).ToList();
            }

            return lista;
        }
    }
}