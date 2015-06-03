using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qqhru.Models
{
    public class Catalog
    {
        public int ID { get; set; }

        [ForeignKey("Father")]
        public int? FatherID { get; set; }

        public virtual Catalog Father { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
