using Microsoft.EntityFrameworkCore;
using P2_AP1_Jefferson_20190267.DAL;
using P2_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Jefferson_20190267.BLL
{
    public class ProyectoBLL
    {
        public static bool Guardar(Proyecto proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }
        private static bool Insertar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Proyecto.Add(proyecto);
                List<DetalleTarea> lista = proyecto.Detalle;

                foreach(var detalle in proyecto.Detalle)
                {
                    contexto.Entry(detalle.tipoTarea).State = EntityState.Modified;
                    detalle.TiempoTotal = lista.Sum(e => e.Tiempo);
                }

                paso = contexto.SaveChanges() > 0; 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyecto = ProyectoBLL.Buscar(id);
                if(proyecto != null)
                {
                    foreach(var detalle in proyecto.Detalle)
                    {
                        detalle.tipoTarea.TipoId -= 1;
                    }
                    contexto.Proyecto.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();


            }
            return paso;
        }
        public static Proyecto Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proyecto proyecto = new Proyecto();
            try
            {
                proyecto = contexto.Proyecto.Include(e => e.Detalle)
                    .Where(x => x.ProyectoId == id)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.tipoTarea)
                    .SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }
        private static bool Modificar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
           
            try
            {
                List<DetalleTarea> detalle = Buscar(proyecto.ProyectoId).Detalle;

                contexto.Database.ExecuteSqlRaw($"Delete FROM DetalleTarea Where ProyectoId={proyecto.ProyectoId}");
                foreach (var item in proyecto.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                List<DetalleTarea> Nuevo = proyecto.Detalle;

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Proyecto.Any(e => e.ProyectoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Proyecto> lista = new List<Proyecto>();
            try
            {
                lista = contexto.Proyecto.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return lista;
        }
    }
}
