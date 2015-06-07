using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using CodeComb.Yuuko.Schema;

namespace Qqhru.Models
{
    public class Article
    {
        [SingleBy]
        public int ID { get; set; }

        public string Title { get; set; }

        public bool Show { get; set; }

        public DateTime Time { get; set; }

        [NotMapped]
        public string _Time
        {
            get
            {
                return Time.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public string Content { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [NotMapped]
        public string Username
        {
            get
            {
                return User.Name;
            }
        }

        [NotMapped]
        public string Sumamry
        {
            get
            {
                var tmp = Content.Split('\n');
                if (tmp.Count() > 10)
                {
                    var ret = "";
                    for (var i = 0; i < 9; i++)
                    {
                        ret += tmp[i];
                    }
                    ret += "<p>……</p>";
                    return ret;
                }
                else return Content;
            }
        }

        [ForeignKey("Catalog")]
        public int CatalogID { get; set; }

        [JsonIgnore]
        public virtual Catalog Catalog { get; set; }

        [NotMapped]
        public string CatalogTitle
        {
            get
            {
                return Catalog.Title;
            }
        }

        public override bool Equals(object obj)
        {
            var data = obj as Article;
            if (data.ID == this.ID) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}