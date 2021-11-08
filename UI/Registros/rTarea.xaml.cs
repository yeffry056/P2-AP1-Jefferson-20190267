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
        
      
        public rTarea()
        {
            InitializeComponent();
            


            TareaComboBox.ItemsSource = TipoTareaBLL.GetTipoTarea();
            TareaComboBox.SelectedValuePath = "TipoId";
            TareaComboBox.DisplayMemberPath = "TipoTareaa";
        }
        


    }
}
