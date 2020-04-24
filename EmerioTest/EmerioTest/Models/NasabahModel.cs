using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmerioTest.Models
{
    public class NasabahModel
    {
        public int AccountID { get; set; }
        [DisplayName("Nama Nasabah")]
        public String Name { get; set; }
    }
}