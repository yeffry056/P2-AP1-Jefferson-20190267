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

namespace P2_AP1_Jefferson_20190267.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cTarea.xaml
    /// </summary>
    public partial class cTarea : Window
    {
        public cTarea()
        {
            InitializeComponent();
        }

        private void BtnConsulta(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyecto>();

            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProyectoBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = ProyectoBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = ProyectoBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = ProyectoBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = ProyectoBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

        }
    }
}
