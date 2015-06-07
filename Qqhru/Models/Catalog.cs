using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Qqhru.Models
{
    public class Catalog
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }

        [NotMapped]
        public int Count { get { return Articles.Count; } }

        public override bool Equals(object obj)
        {
            var data = obj as Catalog;
            if (data.ID == this.ID) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}
