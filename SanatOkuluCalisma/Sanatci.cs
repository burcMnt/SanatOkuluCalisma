using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkuluCalisma
{
    [Table ("Sanatçılar") ]
    public class Sanatci
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Ad { get; set; }

        //virtual olması Entitynin probu override edip lazy loading yapmasını sağlar
        public virtual ICollection<Eser> Eserler { get; set; }

    }
}
