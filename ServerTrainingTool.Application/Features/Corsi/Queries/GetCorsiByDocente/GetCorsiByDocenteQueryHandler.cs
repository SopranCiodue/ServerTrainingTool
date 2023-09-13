using AutoMapper;
using MediatR;
using ServerTrainingTool.Application.Contracts;
using ServerTrainingTool.Domain;

namespace ServerTrainingTool.Application.Features.Corsi.Queries.GetCorsiByDocente
{
    public class GetCorsiByDocenteQueryHandler : IRequestHandler<GetCorsiByDocenteQuery, List<Tabella_CorsiVm>>
    {
        private readonly ITabellaCorsiRepository _tabellaCorsiRepository;

        private readonly IMapper _mapper;

        public GetCorsiByDocenteQueryHandler(ITabellaCorsiRepository tabellaCorsiRepository, IMapper mapper)
        {
            _tabellaCorsiRepository = tabellaCorsiRepository;
            _mapper = mapper;
        }

        public async Task<List<Tabella_CorsiVm>> Handle(GetCorsiByDocenteQuery request, CancellationToken cancellationToken)
        {
            var list = await _tabellaCorsiRepository.GetAsync(x => x.Docente.Contains(request.Docente));

            return _mapper.Map<List<Tabella_CorsiVm>>(list);
        }
    }
}
