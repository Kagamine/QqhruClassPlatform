using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Qqhru.Models
{
    public class Research
    {
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
    }
}