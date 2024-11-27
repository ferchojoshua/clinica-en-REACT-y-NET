using AutoMapper;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;
using Entity = Clinica.Domain.Entities;


namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.UpdateCommands
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalisysRepository _analisysRepository;
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IAnalisysRepository analisysRepository, IMapper mapper)
        {
            
            _analisysRepository = analisysRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data = await _analisysRepository.AnalysisUpdate(analysis);

                if(response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Actualizado!!";
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
