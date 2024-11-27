using AutoMapper;
using Clinica.Application.Dtos.Analisys.Response;
using Clinica.Application.UseCase.UseCase.Analysis.Commands.CreateCommands;
using Clinica.Application.UseCase.UseCase.Analysis.Commands.DeleteCommands;
using Clinica.Application.UseCase.UseCase.Analysis.Commands.UpdateCommands;
using Clinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                 .ForMember(x => x.StateAnalisys, x => x.MapFrom(y => y.State == 1 ? "Activo" : "Inactivo"))
                 .ReverseMap();

            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();
            CreateMap<UpdateAnalysisCommand, Analysis>();
            CreateMap<DeleteAnalysisCommand, Analysis>();
        }
    }
}
