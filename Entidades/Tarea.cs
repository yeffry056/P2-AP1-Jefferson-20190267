using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.Entidades
{
    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String Descripcion { get; set; }

        [ForeignKey("TareaId")]
       // public List<> MyProperty { get; set; }
    }
}
