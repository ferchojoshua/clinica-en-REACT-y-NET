using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Application.UseCase.UseCase.Analysis.Commands.CreateCommands;
using MediatR;

namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.DeleteCommands
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalisysRepository _analysisRepository;
        public DeleteAnalysisHandler(IAnalisysRepository analysisRepository)
        {
            _analysisRepository = analysisRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.Data = await _analysisRepository.AnalysisDelete(request.AnalysisId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Eliminado Exitosamente.";
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
