using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeMedicamentos
    {
        List<TipoDeMedicamentoListDto> GetLista();
        TipoDeMedicamentoEditDto GetipoDeMedicamentoPorId(int? id);
        void Guardar(TipoDeMedicamento tipoDeMedicamento);
        void Borrar(int? id);
        bool Existe(TipoDeMedicamento tipoDeMedicamento);
        bool EstaRelacionado(TipoDeMedicamento tipoDeMedicamento);
    }
}
