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
        
        [OrderBy("Title desc")]
        [Paging(50)]
        public DbSet<User> Teachers { get; set; }

        [Where("UserID = $uid", typeof(int))]
        [OrderBy("Time desc")]
        public DbSet<Research> Researches { get; set; }
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
        #endregion
    }
}