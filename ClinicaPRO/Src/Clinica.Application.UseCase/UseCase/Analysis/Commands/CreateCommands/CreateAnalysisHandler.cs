using AutoMapper;
using Clinica.Application.UseCase.Commons.Bases;
using MediatR;
using Entity = Clinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica.Application.Interface.Interfaces;

namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalisysRepository _analisysRepository;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IAnalisysRepository analisysRepository, IMapper mapper)
        {
            _analisysRepository = analisysRepository;
            _mapper = mapper;
        }
        public  async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
           var response = new BaseResponse<bool>();

        try 
	        {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data = await _analisysRepository.AnalysisRegister(analysis);

                if (response.Data)
            {
                    response.IsSuccess= true;
                    response.Message = "Registro Creado Correctamente.";     
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
