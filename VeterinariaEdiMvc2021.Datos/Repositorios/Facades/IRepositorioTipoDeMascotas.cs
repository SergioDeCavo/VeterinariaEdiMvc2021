using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeMascotas
    {
        List<TipoDeMascotaListDto> GetLista();
        TipoDeMascotaEditDto GetipoDeMascotaPorId(int? id);
        void Guardar(TipoDeMascota tipoDeMascota);
        void Borrar(int? id);
        bool Existe(TipoDeMascota tipoDeMascota);
        bool EstaRelacionado(TipoDeMascota tipoDeMascota);
    }
}
