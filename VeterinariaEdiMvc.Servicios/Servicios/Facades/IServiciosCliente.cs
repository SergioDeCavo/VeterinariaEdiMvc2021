using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosCliente
    {
        List<ClienteListDto> GetLista(string nombreProvincia);
        bool Existe(ClienteEditDto clienteEditDto);
        void Guardar(ClienteEditDto clienteDto);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int clienteId);
    }
}
