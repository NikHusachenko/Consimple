using FluentValidation;

namespace Consimple.Services.CategoryServices.Models
{
    public class CreateCategoryHttpPostViewModel
    {
        public string Name { get; set; }
    }

    public class CreateCategoryHttpPostViewModelValidator : AbstractValidator<CreateCategoryHttpPostViewModel>
    {
        public CreateCategoryHttpPostViewModelValidator()
        {
            RuleFor(model => model.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(63);
        }
    }
}