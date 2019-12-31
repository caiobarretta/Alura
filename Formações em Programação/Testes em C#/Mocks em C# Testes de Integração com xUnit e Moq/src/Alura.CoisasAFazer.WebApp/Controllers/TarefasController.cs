using Microsoft.AspNetCore.Mvc;
using Alura.CoisasAFazer.WebApp.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        IRepositorioTarefas _repo;
        ILogger<CadastraTarefaHandler> _logger;

        public TarefasController()
        {
            var options = new DbContextOptionsBuilder<DbTarefasContext>().Options;
            var contexto = new DbTarefasContext();
            _repo = new RepositorioTarefa(contexto);
            _logger = new LoggerFactory().CreateLogger<CadastraTarefaHandler>();

        }

        public TarefasController(IRepositorioTarefas repositorio, ILogger<CadastraTarefaHandler> logger)
        {
            _repo = repositorio;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler(_repo).Execute(cmdObtemCateg);
            if (categoria == null)
                return NotFound("Categoria não encontrada");

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);

            var handler = new CadastraTarefaHandler(_repo, _logger);
            handler.Execute(comando);
            return Ok();
        }
    }
}