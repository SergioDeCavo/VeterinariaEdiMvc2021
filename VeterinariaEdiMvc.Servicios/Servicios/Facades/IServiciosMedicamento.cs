using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosMedicamento
    {
        List<MedicamentoListDto> GetLista(string descripcion);
        bool Existe(MedicamentoEditDto medicamentoEditDto);
        void Guardar(MedicamentoEditDto medicamentoDto);
        MedicamentoEditDto GetMedicamentoPorId(int? id);
        void Borrar(int medicamentoId);
    }
}
