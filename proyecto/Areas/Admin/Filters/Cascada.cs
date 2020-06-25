using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;


namespace proyecto.Areas.Admin.Filters
{

    [Autenticado]
    public class Cascada
    {
        private Empresa empresa = new Empresa();
        List<Empresa> List_empresa = new List<Empresa>();
        public IEnumerable<SelectListItem> GetEmpresa()
        {
            var data = new ProyectoContext();

            return data.Empresa.Select(x => new SelectListItem
            {
                Text = x.nmempresa,

                Value = x.idempresa.ToString()

            }).ToList();
        }

        public IEnumerable<SelectListItem> GetSucursal(int idempresa)
        {
            var data = new ProyectoContext();

            return data.Sucursal.Where(y => y.empresa_id == idempresa).Select(x => new SelectListItem
            {
                Text = x.nmsucursal,
                Value = x.idsucursal.ToString()
            }).ToList();
        }

        public IEnumerable<SelectListItem> GetCliente(int idempresa)
        {
            var data = new ProyectoContext();

            return data.Cliente.Where(y => y.empresa_id == idempresa).Select(x => new SelectListItem
            {
                Text = x.nmcliente,
                Value = x.idcliente.ToString()
            }).ToList();
        }

    }
}