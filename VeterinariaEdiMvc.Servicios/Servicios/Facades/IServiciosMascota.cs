using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosMascota
    {
        List<MascotaListDto> GetLista(string descripcion);
        bool Existe(MascotaEditDto mascotaEditDto);
        void Guardar(MascotaEditDto mascotaDto);
        MascotaEditDto GetMascotaPorId(int? id);
        void Borrar(int mascotaId);
    }
}
