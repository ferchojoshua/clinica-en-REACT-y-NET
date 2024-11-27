using AutoMapper;
using Clinica.Application.Dtos.Analisys.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCase.Analysis.Queries.GetAllQuerys
{
    public class GetallAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        //private readonly IAnalisysRepository _analisysRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetallAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {
                var analysis = await _unitOfWork.Analysis.GetAllAsync("uspAnalysisList");

                if (analysis is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                    response.Message = "Consulta Exitosamente!!";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }

            return response;
        }
    }
}
