using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qqhru.Models
{
    public class Article
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Time { get; set; }

        public string Content { get; set; }

        [ForeignKey("Catalog")]
        public int CatalogID { get; set; }

        public virtual Catalog Catalog { get; set; }

        public bool IsAnnouncement { get; set; }
    }
}