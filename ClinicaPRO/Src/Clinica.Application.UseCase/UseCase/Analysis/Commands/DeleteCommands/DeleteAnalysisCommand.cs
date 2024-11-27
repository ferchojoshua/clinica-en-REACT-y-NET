using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.DeleteCommands
{
    public class DeleteAnalysisCommand:IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
