using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using System.Data.Entity;
using System.Linq;
using VeterinariaEdiMvc2021.Entidades.Entidades;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioMascotas : IRepositorioMascotas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioMascotas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int mascotaId)
        {
            try
            {
                var mascotaInDb = _context.Mascotas.SingleOrDefault(ma => ma.MascotaId == mascotaId);
                if (mascotaInDb == null)
                {
                    throw new Exception("Mascota inexistente...");
                }
                _context.Entry(mascotaInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una Mascota");
            }
        }

        public bool Existe(Mascota mascota)
        {
            try
            {
                if (mascota.MascotaId == 0)
                {
                    return _context.Mascotas.Any(ma => ma.Nombre == mascota.Nombre);
                }
                return _context.Mascotas.Any(ma => ma.Nombre == mascota.Nombre && ma.MascotaId != mascota.MascotaId);
            }
            catch (Exception)
            {
                throw new Exception("Error al verificar si existe una Mascota");
            }

        }

        public List<MascotaListDto> GetLista(string tipoDeMascota)
        {
            try
            {
                IQueryable<MascotaListDto> listaDto = _context.Mascotas.Include(p => p.TipoDeMascota)
                    .Select(p => new MascotaListDto
                    {
                        MascotaId = p.MascotaId,
                        Nombre = p.Nombre,
                        TipoDeMascota = p.TipoDeMascota.Descripcion,
                        Raza = p.Raza.Descripcion,
                        Cliente = p.Cliente.Apellido
                    });
                if (tipoDeMascota != null)
                {
                    listaDto = listaDto.Where(p => p.TipoDeMascota == tipoDeMascota);


                }
                return listaDto.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer las Mascotas");
            }
        }

        public MascotaEditDto GetMascotaPorId(int? id)
        {
            try
            {
                return _mapper.Map<MascotaEditDto>(_context.Mascotas.SingleOrDefault(ma => ma.MascotaId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer una Mascota");
            }
        }

        public void Guardar(Mascota mascota)
        {
            try
            {
                if (mascota.MascotaId == 0)
                {
                    _context.Mascotas.Add(mascota);
                }
                else
                {
                    var mascotaInDb = _context.Mascotas.SingleOrDefault(ma => ma.MascotaId == mascota.MascotaId);
                    mascotaInDb.MascotaId = mascota.MascotaId;
                    mascotaInDb.TipoDeMascotaId = mascota.TipoDeMascotaId;
                    mascotaInDb.RazaId = mascota.RazaId;
                    mascotaInDb.ClienteId = mascota.ClienteId;
                    mascotaInDb.Nombre = mascota.Nombre;
                    mascotaInDb.FechaDeNacimiento = mascota.FechaDeNacimiento;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar Guardar las Mascotas");
            }
        }
    }
}
