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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[] Track { get; set; }
        public string MimeType { get; set; }
        public Music_Info Information { get; set; }
        public Item_Info Item_Information { get; set; }

        public ICollection<User> Users { get; set; }
        public Music()
        {
            Users = new List<User>();
        }
    }
}
