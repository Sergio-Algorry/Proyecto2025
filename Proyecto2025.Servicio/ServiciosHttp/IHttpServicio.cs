
namespace Proyecto2025.Servicio.ServiciosHttp
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}