using Microsoft.EntityFrameworkCore;
using PrimerParcial_AdrianMendez.DAL;
using PrimerParcial_AdrianMendez.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static bool Modificar(Articulo articulo) {

            bool modificado = false;
            Contexto db = new Contexto();

            try {

                db.Entry(articulo).State = EntityState.Modified;
                modificado = (db.SaveChanges() > 0);

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return modificado;
        }

        public static List<Articulo> GetList(Expression<Func<Articulo , bool>> Expression) {

            List<Articulo> articulosList = new List<Articulo>();
            Contexto db = new Contexto();

            try {

                articulosList = db.Articulos.Where(Expression).ToList();

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return articulosList;
        }

    }
}
