using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qqhru.Models
{
    public class Profession
    {
        public int ID { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// 系主任
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}