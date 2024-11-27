using Clinica.Application.Dtos.Analisys.Response;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Application.UseCase.UseCase.Analysis.Queries.GeyByIdQuerys
{
    public class GetAnalysisByIdQuery : IRequest<BaseResponse<GetAllAnalysisResponseDto>>
    {

        public int AnalysisId { get; set; }

    }
}
