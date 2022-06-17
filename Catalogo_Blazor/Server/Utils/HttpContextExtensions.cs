using Microsoft.EntityFrameworkCore;

namespace Catalogo_Blazor.Server.Utils
{
    public static class HttpContextExtensions
    {
        public async static Task InserirParametroEmPageResponse<T>(this HttpContext context, IQueryable<T> queryable, int quantidadeTotalRegistrosAExibir)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double quantidadeRegistrosTotal = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(quantidadeRegistrosTotal / quantidadeTotalRegistrosAExibir);
            context.Response.Headers.Add("quantidadeRegistrosTotal", quantidadeRegistrosTotal.ToString());
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
        }
    }
}
