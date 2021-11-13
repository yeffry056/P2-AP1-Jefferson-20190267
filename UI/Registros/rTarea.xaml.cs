using P2_AP1_Jefferson_20190267.BLL;
using P2_AP1_Jefferson_20190267.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P2_AP1_Jefferson_20190267.UI.Registros
{
    /// <summary>
    /// Interaction logic for rTarea.xaml
    /// </summary>
    public partial class rTarea : Window
    {

        private Proyecto proyecto = new Proyecto();
        public rTarea()
        {
            InitializeComponent();
            this.DataContext = proyecto;
            
            TareaComboBox.ItemsSource = TipoTareaBLL.GetTipoTarea();
            TareaComboBox.SelectedValuePath = "TipoId";
            TareaComboBox.DisplayMemberPath = "TipoTareaa";
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;

        }
        private void Limpiar()
        {
            this.proyecto = new Proyecto();
            this.DataContext = proyecto;
        }
        private bool Validar()
        {
            bool esValido = true;
            if(TextProyectoId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextDescripcion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }

            return esValido;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
           
            var encontrado = ProyectoBLL.Buscar(proyecto.ProyectoId);

            if(encontrado != null)
            {
                proyecto = encontrado;
                Cargar();
                TextTotal.Text = proyecto.Detalle.Sum(x => x.Tiempo).ToString();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Proyecto no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnAgregarFila(object sender, RoutedEventArgs e)
        {
            proyecto.Detalle.Add(new DetalleTarea
            {
                ProyectoId = proyecto.ProyectoId,
                tipoTarea = (TipoTarea)TareaComboBox.SelectedItem,
                Tiempo = Utilidades.ToInt(TextMinutos.Text),
                TiempoTotal = proyecto.Detalle.Sum(e => e.Tiempo),
                Requerimiento = TextRequerimiento.Text
            }) ;

            Cargar();
            TextTotal.Text = Convert.ToString(proyecto.Detalle.Sum(e => e.Tiempo)); 

            TextRequerimiento.Focus();
            TextRequerimiento.Clear();
            TextMinutos.Clear();
           
        }

        private void BtnRemoverFila(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            var paso = ProyectoBLL.Guardar(proyecto);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            var existe = ProyectoBLL.Buscar(proyecto.ProyectoId);

            if(existe == null)
            {
                MessageBox.Show("No existe el proyecto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ProyectoBLL.Eliminar(proyecto.ProyectoId);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
