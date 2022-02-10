using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Documentos.Commands.CriarDeslocamento
{
    public class EncerrarDeslocamentoCommand : IRequest
    {
        public long DeslocamentoId { get; set; }
        public string Observacao { get; set; }
        public decimal QuilometragemFinal { get; set; }
    }
    public class EncerrarDeslocamentoCommandHandler : IRequestHandler<EncerrarDeslocamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EncerrarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            EncerrarDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();
            var deslocamento = await repositoryDeslocamento
               .FindBy(d => d.Id == request.DeslocamentoId)
               .FirstAsync(cancellationToken);

            deslocamento.FinalizarDeslocamento(request.Observacao, request.QuilometragemFinal);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
