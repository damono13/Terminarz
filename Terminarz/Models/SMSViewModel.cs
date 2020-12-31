using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Terminarz.Models
{
    public class SMSViewModel
    {
        [Key]
        public int IdTelefonu { get; set; }
        public string TelefonNumer { get; set; }
        public string Message { get; set; }
    }
}