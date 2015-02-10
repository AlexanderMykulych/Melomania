using Mlm.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlm.Domain.Abstract.Database
{
    public interface IRepository
    {
        IQueryable<User> users { get; }
        IQueryable<Music> musics { get; }

        void Add(User user);
        void Add(Music music);
         
    }
}
