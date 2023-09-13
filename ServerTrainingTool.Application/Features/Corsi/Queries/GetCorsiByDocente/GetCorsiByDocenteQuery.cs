using MediatR;
using ServerTrainingTool.Domain;

namespace ServerTrainingTool.Application.Features.Corsi.Queries.GetCorsiByDocente
{
    public class GetCorsiByDocenteQuery : IRequest<List<Tabella_CorsiVm>>
    {
        public string Docente { get; set; }

        public GetCorsiByDocenteQuery(string docente)
        {
            Docente = docente ?? throw new ArgumentNullException(nameof(docente));
        }
    }
}
