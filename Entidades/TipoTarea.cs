using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.Entidades
{
    public class TipoTarea
    {
        [Key]
        public int TipoId { get; set; }
        public String  TipoTareaa { get; set; }

    }
}
