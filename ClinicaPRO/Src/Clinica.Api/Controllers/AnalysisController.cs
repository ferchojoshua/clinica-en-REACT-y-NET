using Clinica.Application.UseCase.UseCase.Analysis.Commands.CreateCommands;
using Clinica.Application.UseCase.UseCase.Analysis.Commands.DeleteCommands;
using Clinica.Application.UseCase.UseCase.Analysis.Commands.UpdateCommands;
using Clinica.Application.UseCase.UseCase.Analysis.Queries.GetAllQuerys;
using Clinica.Application.UseCase.UseCase.Analysis.Queries.GeyByIdQuerys;
using Clinica.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> listAnalysis()
        {
            var response = await _mediator.Send(new GetAllAnalysisQuery());
            return Ok(response);
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId });

            return Ok(response);

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> AnalysisUpdate([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("Delete/{analysisId:int}")]
        public async Task<IActionResult> AnalysisDelete(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });

            return Ok(response);
        }
    }
}
