using PrimerParcial_AdrianMendez.BLL;
using PrimerParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrimerParcial_AdrianMendez.UI.Registro {
    /// <summary>
    /// Interaction logic for RegistroArticulo.xaml
    /// </summary>
    public partial class RegistroArticulo : Window {
        public RegistroArticulo() {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender , RoutedEventArgs e) {

            Limpiar();
        }

        private void GuardarButton_Click(object sender , RoutedEventArgs e) {

            Articulo articulo;
            bool guardado = false;

            if (!Validar()) {
                return;
            }

            articulo = LlenaClase();

            if (ProductoIdTextBox.Text == "0" || string.IsNullOrWhiteSpace(ProductoIdTextBox.Text)) {

                guardado = ArticulosBLL.Guardar(articulo);

            } else {

                if (!ExisteEnLaBaseDatos()) {
                    MessageBox.Show("Este articulo no se puede modificar porque no existe");
                    ProductoIdTextBox.Focus();
                    return;
                }
                guardado = ArticulosBLL.Modificar(articulo);

            }

            if (guardado) {
                MessageBox.Show("Guardado :)" , "EXITO" , MessageBoxButton.OK , MessageBoxImage.Exclamation);
            } else {
                MessageBox.Show("No se ah Guardado :(" , "ERROR" , MessageBoxButton.OK , MessageBoxImage.Error);
            }

        }

        private bool ExisteEnLaBaseDatos() {
            Articulo articulo = ArticulosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (articulo != null);
        }

        private void EliminarButton_Click(object sender , RoutedEventArgs e) {

            int productoId = 0;
            Articulo articulo = new Articulo();

            try {

                productoId = Convert.ToInt32(ProductoIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("El ProductoId debe ser un numero entero");
                ProductoIdTextBox.Focus();
                return;

            }

            articulo = ArticulosBLL.Buscar(productoId);

            if (articulo != null) {
                ArticulosBLL.Eliminar(productoId);
                MessageBox.Show("Articulo Eliminado");
            } else {
                MessageBox.Show("Este articulo no existe");
            }

            Limpiar();

        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {

            Articulo articulo = new Articulo();
            int productoId;

            try {//ProductoId

                productoId = Convert.ToInt32(ProductoIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("Producto Id Invalido.");
                return;
            }

            articulo = ArticulosBLL.Buscar(productoId);

            if (articulo != null) {
                LlenaCampo(articulo);
                MessageBox.Show("Articulo encontrado.");

            } else {
                MessageBox.Show("Articulo no encontrado.");
            }


        }

        private void Limpiar() {

            ProductoIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            ExistenciaTextBox.Text = "";
            CostoTextBox.Text = "";
            ValorInventarioTextBox.Text = "";

        }

        private void LlenaCampo(Articulo articulo) {

            ProductoIdTextBox.Text = articulo.ProductoId.ToString();
            DescripcionTextBox.Text = articulo.Descripcion;
            ExistenciaTextBox.Text = articulo.Existencia.ToString();
            CostoTextBox.Text = articulo.Costo.ToString();
            ValorInventarioTextBox.Text = articulo.ValorInventario.ToString();

        }

        private Articulo LlenaClase() {

            Articulo articulo = new Articulo();

            articulo.ProductoId = Convert.ToInt32(ProductoIdTextBox.Text);
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulo.Costo = Convert.ToDecimal(CostoTextBox.Text);
            articulo.ValorInventario = Convert.ToDecimal(ValorInventarioTextBox.Text);


            return articulo;
        }

        private bool Validar() {

            bool validados = true;

            try {//ProductoId

                int id = Convert.ToInt32(ProductoIdTextBox.Text);

            } catch (Exception) {

                validados = false;
                MessageBox.Show("Producto Id Invalido");
            }

            //Descripción
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text)) {
                validados = false;
                MessageBox.Show("Descripción Id Invalida");
            }

            try {//Existencia

                int existencia = Convert.ToInt32(ExistenciaTextBox.Text);

            } catch (Exception) {

                validados = false;
                MessageBox.Show("El campo existencia solo acepta numeros enteros");
            }

            try {//Costo

                decimal costo = Convert.ToDecimal(CostoTextBox.Text);
                if (costo < 0) {
                    validados = false;
                    MessageBox.Show("El costo debe ser un numero entero > 0");
                }

            } catch (Exception) {

                validados = false;
                MessageBox.Show("El costo debe ser un numero entero > 0");
            }

            try {//ValorInventario

                decimal valorInventario = Convert.ToDecimal(ValorInventarioTextBox.Text);
                if (valorInventario < 0) {
                    validados = false;
                    MessageBox.Show("El Valor de Inventario debe ser un numero entero > 0");
                }

            } catch (Exception) {

                validados = false;
                MessageBox.Show("El Valor de Inventario debe ser un numero entero > 0");
            }

            return validados;

        }

        private void ExistenciaTextBox_TextChanged(object sender , TextChangedEventArgs e) {
            CalcularValorInventario();

        }


        private void CostoTextBox_TextChanged(object sender , TextChangedEventArgs e) {

            CalcularValorInventario();
        }

        private void CalcularValorInventario() {
            int existencia = 0;
            decimal costo = 0.0m;

            try {//Existencia

                existencia = Convert.ToInt32(ExistenciaTextBox.Text);

            } catch (Exception) {

            }

            try {//Costo

                costo = Convert.ToDecimal(CostoTextBox.Text);

            } catch (Exception) {

            }

            decimal valorInventario = (costo * existencia);

            ValorInventarioTextBox.Text = valorInventario.ToString();
        }
    }
}
