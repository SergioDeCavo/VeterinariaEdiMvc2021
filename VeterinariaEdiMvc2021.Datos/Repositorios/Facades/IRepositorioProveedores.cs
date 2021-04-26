using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Proveedor;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioProveedores
    {
        List<ProveedorListDto> GetLista(string nombreLocalidad);
        bool Existe(Proveedor proveedor);
        void Guardar(Proveedor proveedor);
        ProveedorEditDto GetProveedorPorId(int? id);
        void Borrar(int proveedorId);
    }
}
