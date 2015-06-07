using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using CodeComb.Yuuko.Schema;

namespace Qqhru.Models
{
    public class Group
    {
        [SingleBy]
        public int ID { get; set; }

        public string Title { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [NotMapped]
        public string Username { get { return User.Name; } }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

        [NotMapped]
        public int Count { get { return Users.Count; } }

        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            var data = obj as Group;
            if (data.ID == this.ID) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}