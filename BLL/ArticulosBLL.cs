﻿using Microsoft.EntityFrameworkCore;
using PrimerParcial_AdrianMendez.DAL;
using PrimerParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial_AdrianMendez.BLL {
    public class ArticulosBLL {

        public static bool Guardar(Articulo articulo) {

            bool guardado = false;
            Contexto db = new Contexto();

            try {

                db.Add(articulo);
                guardado = (db.SaveChanges() > 0);

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return guardado;
        }

        public static Articulo Buscar(int articuloId) {

            Articulo articulo = new Articulo();
            Contexto db = new Contexto();

            try {

                articulo = db.Articulos.Find(articuloId);

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return articulo;
        }

        public static bool Eliminar(int articuloId) {

            bool eliminado = false;
            Contexto db = new Contexto();

            try {

                var articulo = db.Articulos.Find(articuloId);
                db.Entry(articulo).State = EntityState.Deleted;
                eliminado = (db.SaveChanges() > 0);

            } catch (Exception) {

                throw;
            } finally {

                db.Dispose();
            }

            return eliminado;

        }

    }
}