using Microsoft.EntityFrameworkCore;
using PrimerParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial_AdrianMendez.DAL {

    public class Contexto : DbContext{

        public DbSet<Articulo> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = ArticulosDb ; Trusted_Connection = True; ");

        }

    }
}
