﻿using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Medicamento;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioMedicamentos
    {
        List<MedicamentoListDto> GetLista(string tipo);
        bool Existe(Medicamento medicamento);
        void Guardar(Medicamento medicamento);
        MedicamentoEditDto GetMedicamentoPorId(int? id);
        void Borrar(int medicamentoId);
    }
}
