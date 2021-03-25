using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDeMascota
    {
        List<TipoDeMascotaListDto> GetLista();
        TipoDeMascotaEditDto GetipoDeMascotaPorId(int? id);
        void Guardar(TipoDeMascotaEditDto tipoDeMascota);
        void Borrar(int? id);
        bool Existe(TipoDeMascotaEditDto tipoDeMascota);
        bool EstaRelacionado(TipoDeMascotaEditDto tipoMasDto);
    }
}
