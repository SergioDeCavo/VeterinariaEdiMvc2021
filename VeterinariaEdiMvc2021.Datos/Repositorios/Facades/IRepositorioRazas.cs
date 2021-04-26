using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Raza;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioRazas
    {
        List<RazaListDto> GetLista(string tipo);
        bool Existe(Raza raza);
        void Guardar(Raza raza);
        RazaEditDto GetRazaPorId(int? id);
        void Borrar(int razaId);
        bool EstaRelacionado(Raza raza);
    }
}
