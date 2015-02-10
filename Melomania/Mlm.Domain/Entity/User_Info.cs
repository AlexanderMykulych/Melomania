using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mlm.Domain.Entity
{
    [ComplexType]
    public class User_Info
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
    }
}
