using AutoMapper;
using System;
using System.Collections.Generic;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;

namespace VeterinariaEdiMvc2021.Datos.Repositorios
{
    public class RepositorioItemVentas : IRepositorioItemVentas
    {
        private readonly VeterinariaEdiMvc2021DbContext _context;
        private readonly IMapper _mapper;

        public RepositorioItemVentas(VeterinariaEdiMvc2021DbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<ItemVentaListDto> GetItemVentas()
        {

            try
            {
                var lista = _context.ItemVentas; //.Include(v => v.Medicamento).ToList();
                return _mapper.Map<List<ItemVentaListDto>>(lista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
