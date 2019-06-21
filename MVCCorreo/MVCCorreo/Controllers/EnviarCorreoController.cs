using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVCCorreo.Controllers
{
    public class EnviarCorreoController : Controller
    {
        // GET: EnviarCorreo
        public ActionResult Index()
        {
            return View();
        }

        // GET: EnviarCorreo
        public ActionResult EnviarCorreo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarCorreo(String nome, String email, String assunto, String Mensagem)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("contato@dobleve.com.br");
                correo.To.Add("contato@dobleve.com.br");
                correo.Subject = assunto + " - " + nome;
                correo.Body =   "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" + "Assunto: " + assunto + "<br />" + "Comentário: " + Mensagem ;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail5006.smarterasp.net";
                smtp.Port = 8889;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                string suCuentaCorreo = "contato@dobleve.com.br";
                string suPasswordCorreo = "Dblv2019#";
                smtp.Credentials = new System.Net.NetworkCredential(suCuentaCorreo, suPasswordCorreo);

                smtp.Send(correo);
                ViewBag.Mensagem = "Enviado com sucesso!";

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + " - " + ex.StackTrace;
            }

            return View();
        }
    }
}