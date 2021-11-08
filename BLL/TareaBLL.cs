using P2_AP1_Jefferson_20190267.DAL;
using P2_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.BLL
{
    public class TareaBLL
    {
        private static bool Insertar(Tarea tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Tarea.Add(tarea);
                List<DetalleTarea> lista = tarea.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }
    }
}
