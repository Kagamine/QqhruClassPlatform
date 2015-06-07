using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Qqhru.Models
{
    public class Class
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Term { get; set; }

        public string Plan { get; set; }

        public string Plan2 { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        
        [JsonIgnore]
        public virtual User User { get; set; }

        [NotMapped]
        public string Username { get { return User.Name; } }

        public override bool Equals(object obj)
        {
            var data = obj as Class;
            if (data.ID == this.ID) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}