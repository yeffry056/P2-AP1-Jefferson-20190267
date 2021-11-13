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
    /// Interaction logic for cTipoTarea.xaml
    /// </summary>
    public partial class cTipoTarea : Window
    {
        public cTipoTarea()
        {
            InitializeComponent();
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TipoTarea>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:

                        listado = TipoTareaBLL.GetTipoTarea();
                        break;
                    case 1:
                        listado = TipoTareaBLL.GetList(e => e.TipoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;
                    case 2:
                        listado = TipoTareaBLL.GetList(e => e.TipoTareaa.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;

                }
            }
            else
            {
                listado = TipoTareaBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;
           
        }
    }
}
