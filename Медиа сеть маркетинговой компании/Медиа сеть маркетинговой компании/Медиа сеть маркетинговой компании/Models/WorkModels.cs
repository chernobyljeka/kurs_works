using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Медиа_сеть_маркетинговой_компании.Models
{
    public class Advert
    {
        [Key]
        public int id { get; set; }
        public string msg { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }

        public int CatsId { get; set; }
        public Cat Cat { get; set; }
    }
    public class Cat
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
        public ICollection<Advert> adverts { get; set; }
    }
}