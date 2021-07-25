using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkuluCalisma
{
    [Table("Eserler")]
    public class Eser
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Ad { get; set; }
        public int? Yil { get; set; }

        //[ForeignKey("Sanatci")] //bunu koymasada fk olarak anlıyor biz burda kullanımycaz şimdi gelenekten dolayı
        public int SanatciId { get; set; } //burda classadı+Id diye yazıp aşada ilişkiyi belirtince otomatik foreignKey olarak tanımlar.

        public virtual Sanatci Sanatci { get; set; }
    }
}
