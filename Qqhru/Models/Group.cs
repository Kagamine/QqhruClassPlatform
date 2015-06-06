using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qqhru.Models
{
    public class Group
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public string Description { get; set; }
    }
}