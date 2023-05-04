using FluentValidation;

namespace Consimple.Services.ClientServices.Models
{
    public class CreateClientHttpPostViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class CreateClientHttpPostViewModelValidator : AbstractValidator<CreateClientHttpPostViewModel>
    {
        public CreateClientHttpPostViewModelValidator()
        {
            RuleFor(model => model.FirstName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(63);

            RuleFor(model => model.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(63);

            RuleFor(model => model.MiddleName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(63);
        }
    }
}