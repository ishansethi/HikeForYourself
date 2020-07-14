using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Mail;  

namespace hikeforyourselfver3.Models
{
    public class SendEmailViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Display(Name = "Your Email address")]
        [Required(ErrorMessage = "Please enter your mail.")]
        public string FromMail { get; set; }

        [Required(ErrorMessage = "Please enter the contents")]
        public string Contents { get; set; }
     

    }
}