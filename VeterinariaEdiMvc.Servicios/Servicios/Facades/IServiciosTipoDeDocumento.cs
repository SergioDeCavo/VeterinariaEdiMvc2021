using System.Collections.Generic;
using VeterinariaEdiMvc2021.Entidades.DTOs.TipoDeDocumento;
using VeterinariaEdiMvc2021.Entidades.Entidades;

namespace VeterinariaEdiMvc.Servicios.Servicios.Facades
{
    public interface IServiciosTipoDeDocumento
    {
        List<TipoDeDocumentoListDto> GetLista();
        TipoDeDocumentoEditDto GetipoDeDocumentoPorId(int? id);
        void Guardar(TipoDeDocumentoEditDto tipoDeDocumento);
        void Borrar(int? id);
        bool Existe(TipoDeDocumentoEditDto tipoDeDocumento);
        bool EstaRelacionado(TipoDeDocumentoEditDto tipoDocDto);
    }
}
