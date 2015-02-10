using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlm.Domain.Entity
{
    [Table("Musics")]
    public class Music
    {
        public Guid Id { get; set; }
        public byte[] Track { get; set; }
        public Music_Info Information { get; set; }
    }
}
