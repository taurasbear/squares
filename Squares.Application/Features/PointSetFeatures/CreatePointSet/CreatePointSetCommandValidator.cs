using FluentValidation;

namespace Squares.Application.Features.PointSetFeatures.CreatePointSet;

public class CreatePointSetCommandValidator : AbstractValidator<CreatePointSetCommand>
{
    public CreatePointSetCommandValidator()
    {
        RuleFor(command => command.Points)
            .NotEmpty()
            .WithMessage("Points set must have at least one point.");
    }
}