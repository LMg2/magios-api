using Magios.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Magios.Api.Repositories
{
    public class InscripcionesRepo
    {
        public List<Inscripciones> getDatosInscripcion()
        {
            using (var context = new DBMagiosEntities())
            {
                return context.Inscripciones.ToList();
            }
        }

        public void addInscripcion(DatosInscripcion data)
        {
            try
            {
                var inscripciones = new Inscripciones
                {
                    Apellido = data.Apellido,
                    ClaseBarco = data.ClaseBarco,
                    FechaAlta = DateTime.Now,
                    IdCampeonato = data.IdCampeonato,
                    Nombre = data.Nombre,
                    NumeroVela = data.NumeroVela,
                };

                using (var context = new DBMagiosEntities())
                {
                    context.Inscripciones.Add(inscripciones);
                    context.SaveChanges();
                }
                data.IdInscripcion = inscripciones.IdInscripcion;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DatosInscripcion getInscripcion(string claseBarco, string numeroVela)
        {
            DatosInscripcion data = null;
            try
            {
                using (var context = new DBMagiosEntities())
                {
                    var inscripcion = context.Inscripciones.Where(i => i.ClaseBarco == claseBarco && i.NumeroVela == numeroVela).FirstOrDefault();
                    if (inscripcion != null)
                    {
                        data = new DatosInscripcion
                        {
                            Apellido = inscripcion.Apellido,
                            NumeroVela = inscripcion.NumeroVela,
                            ClaseBarco = inscripcion.ClaseBarco,
                            Nombre = inscripcion.Nombre,
                            IdCampeonato = inscripcion.IdCampeonato,
                            IdInscripcion = inscripcion.IdInscripcion
                        };
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return data;
        }

        public void deleteInscripcion(string clasebarco, string numeroVela)
        {
            try
            {
                using (var context = new DBMagiosEntities())
                {
                    var inscripcion = context.Inscripciones.Where(i => i.ClaseBarco == clasebarco && i.NumeroVela == numeroVela).FirstOrDefault();
                    if (inscripcion != null)
                    {
                        context.Entry(inscripcion).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}