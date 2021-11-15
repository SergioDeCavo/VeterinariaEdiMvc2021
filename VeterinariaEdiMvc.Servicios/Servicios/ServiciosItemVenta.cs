using System;
using System.Collections.Generic;
using VeterinariaEdiMvc.Servicios.Servicios.Facades;
using VeterinariaEdiMvc2021.Datos.Repositorios;
using VeterinariaEdiMvc2021.Datos.Repositorios.Facades;
using VeterinariaEdiMvc2021.Entidades.DTOs.ItemVenta;

namespace VeterinariaEdiMvc.Servicios.Servicios
{
    public class ServiciosItemVenta : IServiciosItemVenta
    {
        private readonly IRepositorioItemVentas repositorio;

        public ServiciosItemVenta(RepositorioItemVentas repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<ItemVentaListDto> GetItemVentas()
        {
            try
            {
                return repositorio.GetItemVentas();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
