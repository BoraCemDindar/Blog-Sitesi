using Blog.BLL.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext")
        {
            //Migration işlemleri için DbContext(BlogContext) ile Migration sınıfı eşleştirilmelidir.
           
        }

        public virtual DbSet<Makale> Makaleler { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
        public virtual DbSet<Uye> Uyeler { get; set; }
        public virtual DbSet<Etiket> Etiketler { get; set; }

    }
}
