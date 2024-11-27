using AutoMapper;
using Clinica.Application.Dtos.Analisys.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinica.Application.UseCase.UseCase.Analysis.Queries.GeyByIdQuerys
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAllAnalysisResponseDto>>
    {
        //private readonly IAnalisysRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

        public AnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
                
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetAllAnalysisResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAllAnalysisResponseDto>();


            try
            {
                var analysis = await _unitOfWork.Analysis.GetByIdAsync("uspAnalysisByid", new {request.AnalysisId});

                if (analysis is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se Encontraron Registros";
                    return response;

                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetAllAnalysisResponseDto>(analysis);
                response.Message = "Consulta Exitosa";

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;

        }
    }
}
