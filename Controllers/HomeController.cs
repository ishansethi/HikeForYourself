using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikeforyourselfver3.Models;
using hikeforyourselfver3.Utils;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Net.Mail;
using Rotativa;



namespace hikeforyourselfver3.Controllers

{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Contact(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    //String attachments = model.Attachments
                    EmailSender es = new EmailSender();

                 
                    es.Send(toEmail, subject, contents);
                    ViewBag.Result = "Email has been send.";
                    ModelState.Clear();
                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "Your Events Page";


            return View(db.Hikings.ToList());
        }

       // private Entities db = new Entities();


        [Authorize]
        public ActionResult MyEvents()
        {
        ViewBag.Message = "Your My Events Page";
            var userId = User.Identity.GetUserId();
            var hikeBookings = db.HikeBookings.Include(h => h.AspNetUser).Include(h => h.Hiking);
            //return View(hikeBookings.ToList());
            return View(db.HikeBookings.Where(h => h.AspNetUserId == userId).ToList());     
        }

        
        public ActionResult ExportPDF()
        {
            Dictionary<string, string> cookieCollection = new Dictionary<string, string>();
            foreach (var key in Request.Cookies.AllKeys)
            {
                cookieCollection.Add(key, Request.Cookies.Get(key).Value);
            }
            return new Rotativa.ActionAsPdf("MyEvents")
            {
                FileName = Server.MapPath("~/Content/Det.pdf"),
                Cookies = cookieCollection
            };
        }

        [Authorize(Roles = "Admin")]
        
        public ActionResult AdminConsole()
        {
            ViewBag.Message = "Admin Page";
            
            return View();
        }

        public ActionResult Mail()
        {
          return View();
        }


      
       [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Mail(AdminEmail model, List<HttpPostedFileBase> attachments)
        {
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                foreach (HttpPostedFileBase attachment in attachments)
                {
                    if (attachment != null)
                    {
                        string fileName = Path.GetFileName(attachment.FileName);
                        mm.Attachments.Add(new Attachment(attachment.InputStream, fileName));
                    }
                }
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                ViewBag.Message = "Email sent.";
            }
            return View();
        }
    }
}