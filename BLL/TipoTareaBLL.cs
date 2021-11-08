using P2_AP1_Jefferson_20190267.DAL;
using P2_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.BLL
{
    public class TipoTareaBLL
    {
        public static List<TipoTarea> GetTipoTarea()
        {
            List<TipoTarea> lista = new List<TipoTarea>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TipoTarea.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
