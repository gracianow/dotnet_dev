using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppEmail.Models;


namespace WebAppEmail.Views
{
    public class ContatoController : Controller
    {
        private string errorMessage;

        // GET: Contato
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contato
        public ActionResult Contato()
        {
            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contato(Contato objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {

                Thread email = new Thread(delegate ()
                {
                    string from = "contato@dobleve.com.br"; //example:- sourabh9303@gmail.com
                    using (MailMessage mail = new MailMessage(from, objModelMail.Email))
                    {
                        mail.Subject = objModelMail.Assunto;
                        mail.Body = objModelMail.Mensagem;
                        if (fileUploader != null)
                        {
                            string fileName = Path.GetFileName(fileUploader.FileName);
                            mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                        }
                        mail.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "mail.dobleve.com.br";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCredential = new NetworkCredential(from, "Dblv2019#");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = networkCredential;
                        smtp.Port =25;
                        smtp.Send(mail);
                        ViewBag.Message = "Sent";
                    }
                });
                email.IsBackground = true;
                email.Start();
                //ParsingTemplate();
                return View("Sent", objModelMail);
            }
            else
            {
                return Error("");
            }
        }

        private void ParsingTemplate()
        {
            throw new NotImplementedException();
        }

        private ActionResult Error(string v)
        {
            throw new NotImplementedException();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contato(Contato model)
        {
                if (ModelState.IsValid)
                {
                    errorMessage = "";
                    var body = "<p>E-mail de: {0} ({1})</p><p>Mensagem:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("contato@dobleve.com.br"));  // replace with valid value 
                    message.From = new MailAddress(model.Email);  // replace with valid value
                    message.Subject = model.Assunto;
                    message.Body = string.Format(body, model.Nome, model.Email, model.Assunto, model.Mensagem);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                        message.Dispose();
                        return RedirectToAction("Sent");

                }
                }
            else{
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        System.Diagnostics.Debug.WriteLine(String.Format("ModelState Error: {0}", error.ErrorMessage));
                        errorMessage = error.ToString();
                    }

                }
                    return RedirectToAction("ContatoForm"); 
            }
            
            ViewBag.errorMessage = errorMessage;

            return View(model);

        }
        */

        // GET: Contato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
