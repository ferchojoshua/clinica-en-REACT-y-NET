using FluentValidation;

namespace Clinica.Application.UseCase.UseCase.Analysis.Commands.CreateCommands
{
    public class CreateAnalysisValidator : AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El Campo Nombre no puede ser Nulo")
                .NotNull().WithMessage("El Campo Nombre no puede Vacio");
        }
    }
}
