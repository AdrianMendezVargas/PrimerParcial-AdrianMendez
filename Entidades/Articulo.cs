using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimerParcial_AdrianMendez.Entidades {
    public class Articulo {

        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        public Articulo() {
            ProductoId = 0;
            Descripcion = "";
            Existencia = 0;
            Costo = 0.0m;
            ValorInventario = 0.0m;
        }
    }
}
