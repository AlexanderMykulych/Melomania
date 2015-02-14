using Mlm.Domain.Abstract.Database;
using Mlm.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlm.Domain.DataBase
{
    public class DataBaseContext : DbContext, IRepository
    {
        public DataBaseContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Music> Musics { get; set; }

        public IQueryable<User> users
        {
            get
            {
                return Users;
            }
        }
        public IQueryable<Music> musics
        {
            get
            {
                return Musics;
            }
        }

        public void Add(User user)
        {
            var item = Users.FirstOrDefault(x => x.Login == user.Login);
            
            if (item == null)
                return;

            Users.Add(user);
            SaveChanges();
        }

        public void Add(Music music)
        {
            var item = Musics.FirstOrDefault(x => x.Information.Name == music.Information.Name);

            if (item == null)
                return;

            Musics.Add(music);
            SaveChanges();
        }

        public void SaveChange()
        {
            SaveChanges();
        }
    }
}
