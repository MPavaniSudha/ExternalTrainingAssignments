using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExternalWebAPIPrj1.Models
{
    public class Address
    {
        [Key]
        public int SNO { get; set; }

        public string DoorNo { get; set; }

        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [ForeignKey("employee")]
        public int EmpNo { get; set; }
        public virtual Employee employee { get; set; }
    }
}