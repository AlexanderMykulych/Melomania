using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mlm.Domain.Entity
{
    [ComplexType]
    public class Image
    {
        public byte[] Picture { get; set; }
        public string MimeType { get; set; }
    }
}
