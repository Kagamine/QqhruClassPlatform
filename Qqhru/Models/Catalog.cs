using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using CodeComb.Yuuko.Schema;

namespace Qqhru.Models
{
    public class Catalog
    {
        [SingleBy]
        public int ID { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }

        [NotMapped]
        public int Count
        {
            get
            {
                try
                {
                    return Articles.Count;
                }
                catch
                {
                    return 0;
                }
            }
        }

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
