using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc2021.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoDeDocumentos
    {
        List<TipoDeDocumentoListDto> GetLista();
        TipoDeDocumentoEditDto GetipoDeDocumentoPorId(int? id);
        void Guardar(TipoDeDocumento tipoDeDocumento);
        void Borrar(int? id);
        bool Existe(TipoDeDocumento tipoDeDocumento);
    }
}
