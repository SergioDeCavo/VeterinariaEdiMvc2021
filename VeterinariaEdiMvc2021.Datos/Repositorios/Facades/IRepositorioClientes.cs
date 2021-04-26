using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.Cliente;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetLista(string nombreProvincia);
        bool Existe(Cliente cliente);
        void Guardar(Cliente cliente);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int clienteId);
    }
}
