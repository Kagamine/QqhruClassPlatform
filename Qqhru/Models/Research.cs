using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using CodeComb.Yuuko.Schema;

namespace Qqhru.Models
{
    public class Research
    {
        [SingleBy]
        public int ID { get; set; }

        public int UserID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public byte[] File { get; set; }

        public DateTime Time { get; set; }

        [NotMapped]
        public string _Time { get { return Time.ToString("yyyy-MM-dd HH:mm"); } }

        public string Hint { get; set; }

        public override bool Equals(object obj)
        {
            var data = obj as Research;
            if (data.ID == this.ID) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}