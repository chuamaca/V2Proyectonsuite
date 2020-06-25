using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;


using System.Net;
using System.Net.Mail;

using proyecto.Areas.Client.Filters;

namespace proyecto.Areas.Client.Controllers
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



        public void envioMensajeEmail(string stServidor, string stusuario, string stPassword,
           string stFrom, string stNombreFrom, string stTo, string stAsunto, string stMensaje, string stArchivo, string stArchivo2, string stoCC)
        {
            try
            {
                MailMessage oMail = new MailMessage();
                oMail.From = new MailAddress(stFrom, stNombreFrom);
                oMail.To.Add(stTo);
                MailAddress bcc = new MailAddress(stoCC);
                oMail.Bcc.Add(bcc);
                oMail.Subject = stAsunto;
                oMail.Body = stMensaje;
                oMail.IsBodyHtml = true;


                if (stArchivo != "")
                {
                    oMail.Attachments.Add(new Attachment(stArchivo));
                }
                if (stArchivo2 != "")
                {
                    oMail.Attachments.Add(new Attachment(stArchivo2));
                }


                SmtpClient oSMTPServer = new SmtpClient();
                oSMTPServer.UseDefaultCredentials = false;
                oSMTPServer.Host = stServidor;

                oSMTPServer.Port = 587;
                oSMTPServer.Credentials = new System.Net.NetworkCredential(stusuario, stPassword);
                oSMTPServer.EnableSsl = true;

                oSMTPServer.Send(oMail);

                oSMTPServer.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}