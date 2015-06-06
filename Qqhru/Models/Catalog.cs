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
    }
}
