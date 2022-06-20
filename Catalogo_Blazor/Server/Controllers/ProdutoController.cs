using Catalogo_Blazor.Server.Context;
using Catalogo_Blazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("categorias/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetProdutosCategoria( int id)
        {
            var produtos = await _appDbContext.Produtos.Where(p => p.CategoriaId.Equals(id)).ToListAsync();
            return produtos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            var produtos = await _appDbContext.Produtos.AsNoTracking().ToListAsync();
            return produtos;
        }

        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _appDbContext.Produtos.FindAsync(id);
            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Add(Produto produto)
        {
            _appDbContext.Add(produto);
            await _appDbContext.SaveChangesAsync();
            var retorno = new CreatedAtRouteResult("GetProduto", new { id = produto.ProdutoId }, produto);
            return retorno;
        }

        [HttpPut]
        public async Task<ActionResult<Produto>> Update(Produto produto)
        {
            _appDbContext.Entry(produto).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Remove(int id)
        {
            var produtoRemoved = new Produto() { ProdutoId = id };
            _appDbContext.Remove(produtoRemoved);
            await _appDbContext.SaveChangesAsync();
            return Ok(produtoRemoved);
        }

    }
}
