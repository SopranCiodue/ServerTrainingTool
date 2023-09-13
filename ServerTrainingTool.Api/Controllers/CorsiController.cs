using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerTrainingTool.Application.Contracts;
using ServerTrainingTool.Application.Features.Corsi.Queries.GetCorsiByDocente;
using ServerTrainingTool.Domain;
using System.Linq.Expressions;

namespace ServerTrainingTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorsiController : ControllerBase
    {
        private readonly ITabellaCorsiRepository _corsiRepository;

        private readonly IMediator _mediator;

        public CorsiController(ITabellaCorsiRepository corsiRepository, IMediator mediator)
        {
            _corsiRepository = corsiRepository;
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetCorsiByDocente(string docente) {

            var corsi = await _corsiRepository.GetCorsiByDocente(docente);
            return Ok(corsi);
        }

        [HttpGet("docente1")]
        public async Task<IActionResult> GetCorsiByDocente1(string docente) {

            //Expression<Func<Tabella_Corsi, bool>> predicate = x => x.Docente.Contains(docente);
            //var corsi = await _corsiRepository.GetAsync(x => x.Docente.Contains(docente));
            var corsi = await _corsiRepository.GetAsync(x => x.Docente.Contains(docente), null, true);
            return Ok(corsi);
        
        }

        [HttpGet("mediator")]

        public async Task<IActionResult> GetCorsiByDocente2(string docente) {

            var query = new GetCorsiByDocenteQuery(docente);

            var list = await _mediator.Send(query);

            return Ok(list);
        }

    }
}
