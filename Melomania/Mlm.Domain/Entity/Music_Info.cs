using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mlm.Domain.Entity
{
    [ComplexType]
    public class Music_Info
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Album { get; set; }

    }
}
