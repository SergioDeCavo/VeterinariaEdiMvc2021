using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosCliente
    {
        List<ClienteListDto> GetLista(string nombreProvincia);
        bool Existe(ClienteEditDto clienteEditDto);
        void Guardar(ClienteEditDto clienteDto);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int clienteId);
        List<Cliente> GetLista(int localidadId);
        List<Cliente> GetLista();
    }
}
