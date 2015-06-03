using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qqhru.Models
{
    public class Research
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public byte[] File { get; set; }

        public DateTime Time { get; set; }

        public string Hint { get; set; }
    }
}