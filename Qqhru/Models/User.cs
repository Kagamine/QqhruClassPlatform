using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qqhru.Models
{
    public enum UserRole
    {
        学生,
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
        public int ProfessionID { get; set; }

        public virtual Profession Profession { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public virtual ICollection<Research> Researches { get; set; }
    }
}