using Clinica.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.UpdateCommands
{
    public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
    }
}
