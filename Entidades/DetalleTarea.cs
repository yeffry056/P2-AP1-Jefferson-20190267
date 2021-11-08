using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.Entidades
{
    public class DetalleTarea
    {
        [Key]
        public int Id { get; set; }
        public String Requerimiento { get; set; }
        public int Tiempo { get; set; }
        public int TiempoTotal { get; set; }
        public int TareaId { get; set; }

        [ForeignKey("TipoId")]
        public TipoTarea tipoTarea { get; set; }
    }
}
