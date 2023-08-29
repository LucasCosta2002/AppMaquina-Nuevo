namespace AppMaquina.Client.Servicios
{
    public interface IHTTPServicio
    {
        Task<HTTPRespuesta<T>> Get<T>(string url);

    }
}