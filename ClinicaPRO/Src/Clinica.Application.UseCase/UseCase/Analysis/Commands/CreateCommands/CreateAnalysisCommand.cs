using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }

    }
}
