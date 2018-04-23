using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DataModel
{
    [Table("Etiketler")]
    public class Etiket : EntityBase
    {
        [Required(ErrorMessage = "Lütfen etiket içeriği giriniz!")]
        [StringLength(30, ErrorMessage = "İçerik {0} karakterden uzun olmamalıdır!")]
        public string Icerik { get; set; }

        //Relations
        public virtual IList<Makale> Makaleler { get; set; }
    }
}
