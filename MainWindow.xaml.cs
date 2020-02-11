using PrimerParcial_AdrianMendez.UI.Consulta;
using PrimerParcial_AdrianMendez.UI.Registro;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimerParcial_AdrianMendez {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void RegitroArticuloMenuItem_Click(object sender , RoutedEventArgs e) {
            RegistroArticulo registroArticulo = new RegistroArticulo();
            registroArticulo.Owner = this;
            registroArticulo.ShowDialog();
        }

        private void ConsultaArticulosMenuItem_Click(object sender , RoutedEventArgs e) {
            ConsultaArticulos consultaArticulos = new ConsultaArticulos();
            consultaArticulos.Owner = this;
            consultaArticulos.ShowDialog();
        }
    }
}
