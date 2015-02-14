using Mlm.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mlm.Web.Models
{
    public class ProfileModel
    {
        public ProfileModel(User user)
        {
            Login = user.Login;
            Name = user.Information.Name;
            Surname = user.Information.Surname;
            Address = user.Information.Address;
            About = user.Information.About;
            Id = user.Id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string About { get; set; }

    }
}