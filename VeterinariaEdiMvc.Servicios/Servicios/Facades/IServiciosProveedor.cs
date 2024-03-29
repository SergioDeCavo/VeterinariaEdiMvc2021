﻿using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosProveedor
    {
        List<ProveedorListDto> GetLista(string nombreLocalidad);
        bool Existe(ProveedorEditDto proveedorEditDto);
        void Guardar(ProveedorEditDto proveedorDto);
        ProveedorEditDto GetProveedorPorId(int? id);
        void Borrar(int proveedorId);
        List<Proveedor> GetLista(int localidadId);
        List<Proveedor> GetLista();
    }
}
