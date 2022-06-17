using Catalogo_Blazor.Server.Context;
using Catalogo_Blazor.Server.Utils;
using Catalogo_Blazor.Shared.Models;
using Catalogo_Blazor.Shared.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo_Blazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CategoriaController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> Get([FromQuery] Paginacao paginacao, [FromQuery] string nome)
    {
        var queryable = _appDbContext.Categorias.AsQueryable();
        if (!string.IsNullOrEmpty(nome) && nome != "***")
        {
            queryable = queryable.Where(c => c.Nome.Contains(nome.Trim()));
        }
        await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.QuantidadePorPagina);
        var retorno = await queryable.Paginar(paginacao).ToListAsync();
        return retorno;
    }

    [HttpGet("{id}", Name = "GetCategoria")]
    public async Task<ActionResult<Categoria>> Get(int id)
    {
        return await _appDbContext.Categorias.AsNoTracking().FirstOrDefaultAsync( x => x.CategoriaId == id);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Post(Categoria categoria)
    {
        _appDbContext.Add(categoria);
        await _appDbContext.SaveChangesAsync();
        return new CreatedAtRouteResult(nameof(CategoriaController.Post), new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut]
    public async Task<ActionResult<Categoria>> Put(Categoria categoria)
    {
        _appDbContext.Update(categoria);        
        await _appDbContext.SaveChangesAsync();
        return Ok(categoria);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Categoria>> Delete(int id)
    {
        var categoriaRemoved = new Categoria { CategoriaId = id };
        _appDbContext.Remove(categoriaRemoved);
        await _appDbContext.SaveChangesAsync();
        return Ok(categoriaRemoved);
    }
}
