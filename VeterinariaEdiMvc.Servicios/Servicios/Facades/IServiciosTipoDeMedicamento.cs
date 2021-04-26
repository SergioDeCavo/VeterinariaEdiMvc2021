using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeMedicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDeMedicamento
    {
        List<TipoDeMedicamentoListDto> GetLista();
        TipoDeMedicamentoEditDto GetipoDeMedicamentoPorId(int? id);
        void Guardar(TipoDeMedicamentoEditDto tipoDeMedicamento);
        void Borrar(int? id);
        bool Existe(TipoDeMedicamentoEditDto tipoDeMedicamento);
        bool EstaRelacionado(TipoDeMedicamentoEditDto tipoMedDto);
    }
}
