using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Qqhru.Models
{
    public enum UserRole
    {
        老师,
        超级管理员
    }

    public enum Title
    {
        助教,
        讲师,
        副教授,
        教授
    }

    public enum Sex
    {
        男,
        女
    }

    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        [ForeignKey("Profession")]
        public int? ProfessionID { get; set; }

        [JsonIgnore]
        public virtual Profession Profession { get; set; }

        [NotMapped]
        public string ProfessionTitle
        {
            get { return Profession != null ? Profession.Title : "无"; }
        }

        [ForeignKey("Group")]
        public int? GroupID { get; set; }

        [JsonIgnore]
        public virtual Group Group { get; set; }

        [NotMapped]
        public string GroupTitle
        {
            get { return Group != null ? Group.Title : "无"; }
        }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        [NotMapped]
        public string _Sex { get { return Sex.ToString(); } }

        public Title Title { get; set; }

        [NotMapped]
        public string _Title { get { return Title.ToString(); } }

        [JsonIgnore]
        public virtual ICollection<Research> Researches { get; set; }

        public int ResearchCount
        {
            get { return Researches.Count; }
        }
    }
}