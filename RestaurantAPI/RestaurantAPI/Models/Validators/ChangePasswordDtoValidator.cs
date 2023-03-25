using FluentValidation;

namespace RestaurantAPI.Models.Validators
{
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator()
        {
            RuleFor(p => p.CurrentPassword)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(p => p.NewPassword)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(p => p.ConfirmNewPassword)
                .Equal(p => p.NewPassword);
        }
    }
}
