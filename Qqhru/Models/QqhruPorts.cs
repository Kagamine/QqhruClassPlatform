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
            Catalogs = DB.Catalogs.AsNoTracking();
            Articles = DB.Articles.AsNoTracking();
            Teachers = DB.Users.AsNoTracking();
            Researches = DB.Researches.AsNoTracking();
            Groups = DB.Groups.AsNoTracking();
            GroupMembers = DB.Users.AsNoTracking();
            Classes = DB.Classes.AsNoTracking();
            PendingArticles = DB.Articles.AsNoTracking();
        }

        #region DBContext
        [DbContext]
        public QqhruContext DB { get; set; }
        #endregion

        #region 数据源
        public IQueryable<Catalog> Catalogs { get; set; }

        [WhereOptional("CatalogID = $cid", typeof(int))]
        [Where("Show = true")]
        [OrderBy("Time desc")]
        [Paging(5)]
        public IQueryable<Article> Articles { get; set; }

        [Where("Show = false")]
        [OrderBy("Time asc")]
        public IQueryable<Article> PendingArticles { get; set; }

        [OrderBy("Title desc")]
        [Paging(50)]
        public IQueryable<User> Teachers { get; set; }

        [Where("UserID = $uid", typeof(int))]
        [OrderBy("Time desc")]
        public IQueryable<Research> Researches { get; set; }

        [OrderBy("ID asc")]
        [Paging(50)]
        public IQueryable<Group> Groups { get; set; }

        [Where("GroupID = $gid", typeof(int))]
        public IQueryable<User> GroupMembers { get; set; }

        [OrderBy("ID desc")]
        [Paging(50)]
        public IQueryable<Class> Classes { get; set; }
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


        [DetailPort(DetailPortFunction.Delete, DetailPortFunction.Edit, DetailPortFunction.Insert)]
        [Binding("Researches")]
        public User ResearchDetail { get; set; }
        #endregion
    }
}