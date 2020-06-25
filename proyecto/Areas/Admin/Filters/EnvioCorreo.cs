using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;

namespace proyecto.Areas.Admin.Filters
{
    public class EnvioCorreo
    {

        public void envioMensajeEmail(string stServidor, string stusuario, string stPassword,
           string stFrom, string stNombreFrom, string stTo, string stAsunto, string stMensaje, string stArchivo,string stArchivo2, string stoCC)
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