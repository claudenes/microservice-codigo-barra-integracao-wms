using Domain.DTO;
using Domain.Interface.Service;

namespace API.Endpoints
{
    public class IntegrarCodigoBarra
    {
        public static string Template => "/integrarcodigobarra";
        public static string[] Methods => new[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static async Task<IResult> Action(CodigoBarrasIntegrarDTO codigoBarraIntegrarDTO,
                                                 IIntegracaoService service)
        {
            try
            {
                var ret = await service.IntegrarCodigoBarra(codigoBarraIntegrarDTO);
                return Results.Ok(ret);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new
                {
                    Mensagem = $"Erro ao tentar integrar código de barras: {ex.Message}"
                });

            }
        }
    }
}
