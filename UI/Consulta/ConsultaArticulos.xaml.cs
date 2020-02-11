using PrimerParcial_AdrianMendez.BLL;
using PrimerParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrimerParcial_AdrianMendez.UI.Consulta {
    /// <summary>
    /// Interaction logic for ConsultaArticulos.xaml
    /// </summary>
    public partial class ConsultaArticulos : Window {
        public ConsultaArticulos() {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {
            CargarResultados();
        }

        private void CargarResultados() {

            List<Articulo> articulosList = new List<Articulo>();

            if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text)) {

                switch (FiltroComboBox.SelectedIndex) {

                    case 0:  //todo
                        articulosList = ArticulosBLL.GetList(a => true);
                        break;

                    case 1: //id
                        int.TryParse(CriterioTextBox.Text , out int productoId);
                        articulosList = ArticulosBLL.GetList(a => a.ProductoId == productoId);
                        break;

                    case 2:  //costo
                        decimal.TryParse(CriterioTextBox.Text , out decimal costo);
                        articulosList = ArticulosBLL.GetList(a => a.Costo == costo);
                        break;

                    case 3: //Descripcion
                        articulosList = ArticulosBLL.GetList(a => a.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }

            } else {

                articulosList = ArticulosBLL.GetList(p => true);
            }

            ResultadosDataGrid.ItemsSource = articulosList;

            

        }
    }
}
