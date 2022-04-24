using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactSurName { get; set; }
        public string ContactMail { get; set; }
        public DateTime ContactDate { get; set; }
        public string ContactContent { get; set; }
    }
}