using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mlm.Domain.Entity
{
    [ComplexType]
    public class Comment
    {
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
