using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeComb.Yuuko;
using CodeComb.Yuuko.Schema;

namespace Qqhru.Models
{
    public class QqhruPorts : PortsContext
    {
        public QqhruPorts()
        {
            DB = new QqhruContext();
            Catalogs = DB.Catalogs;
            Articles = DB.Articles;
            Teachers = DB.Users;
            Researches = DB.Researches;
            Groups = DB.Groups;
            GroupMembers = DB.Users;
            Classes = DB.Classes;
            PendingArticles = DB.Articles;
        }

        #region DBContext
        [DbContext]
        public QqhruContext DB { get; set; }
        #endregion

        #region 数据源
        public DbSet<Catalog> Catalogs { get; set; }

        [WhereOptional("CatalogID = $cid", typeof(int))]
        [OrderBy("Time desc")]
        [Paging(5)]
        public DbSet<Article> Articles { get; set; }

        [Where("Show = false")]
        [OrderBy("Time asc")]
        public DbSet<Article> PendingArticles { get; set; }

        [OrderBy("Title desc")]
        [Paging(50)]
        public DbSet<User> Teachers { get; set; }

        [Where("UserID = $uid", typeof(int))]
        [OrderBy("Time desc")]
        public DbSet<Research> Researches { get; set; }

        [OrderBy("ID asc")]
        [Paging(50)]
        public DbSet<Group> Groups { get; set; }

        [Where("GroupID = $gid", typeof(int))]
        public DbSet<User> GroupMembers { get; set; }

        [OrderBy("ID desc")]
        [Paging(50)]
        public DbSet<Class> Classes { get; set; }
        #endregion

        #region Ports
        [CollectionPort]
        [Binding("Catalogs")]
        public List<Catalog> CatalogList { get; set; }

        [CollectionPort]
        [Binding("Articles")]
        public List<Article> ArticleList { get; set; }

        [CollectionPort]
        [Binding("Teachers")]
        public List<User> TeacherList { get; set; }

        [CollectionPort]
        [Binding("Researches")]
        public List<Research> ResearchList { get; set; }

        [CollectionPort]
        [Binding("Groups")]
        public List<Group> GroupList { get; set; }

        [CollectionPort]
        [Binding("GroupMembers")]
        public List<User> GroupMemberList { get; set; }

        [CollectionPort]
        [Binding("Classes")]
        public List<Class> ClassList { get; set; }

        [CollectionPort]
        [Binding("PendingArticles")]
        public List<Article> PendingArticleList { get; set; }

        [DetailPort(DetailPortFunction.Delete, DetailPortFunction.Edit, DetailPortFunction.Insert)]
        [Binding("Catalogs")]
        public Catalog CatalogDetail { get; set; }

        [DetailPort(DetailPortFunction.Delete, DetailPortFunction.Edit, DetailPortFunction.Insert)]
        [Binding("Articles")]
        public Catalog ArticleDetail { get; set; }

        [DetailPort(DetailPortFunction.Delete, DetailPortFunction.Edit, DetailPortFunction.Insert)]
        [Binding("Groups")]
        public Group GroupDetail { get; set; }


        [DetailPort(DetailPortFunction.Delete, DetailPortFunction.Edit, DetailPortFunction.Insert)]
        [Binding("Teachers")]
        public User TeacherDetail { get; set; }
        #endregion
    }
}