using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Mascota;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioMascotas
    {
        List<MascotaListDto> GetLista(string tipo);
        bool Existe(Mascota mascota);
        void Guardar(Mascota mascota);
        MascotaEditDto GetMascotaPorId(int? id);
        void Borrar(int mascotaId);
    }
}
