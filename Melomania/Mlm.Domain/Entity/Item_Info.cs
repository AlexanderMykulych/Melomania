using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Mlm.Domain.Entity
{
    [ComplexType]
    public class Item_Info
    {
        public int Like_Count { get; set; }
        public int Repost_Count { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } 
        public Item_Info()
        {
            Comments = new List<Comment>();
        }
    }
}
