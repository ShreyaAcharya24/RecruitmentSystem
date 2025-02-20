using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentSystem.DTOs;
using RecruitmentSystem.Models;

public class HiringDriveValidator : AbstractValidator<HiringDriveDto>
{

    public HiringDriveValidator()
    {
        RuleFor(x => x.DriveName)
                .NotEmpty()
                .WithMessage("Drive name is required.")
                .MaximumLength(100)
                .WithMessage("Drive name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z ]*$")
                .WithMessage("Drive name can only contain letters and spaces.");

        RuleFor(x => x.Year)
            .NotEmpty()
            .WithMessage("Year is required")
            .InclusiveBetween(1900, 2100)
            .WithMessage("Year must be between 1900 and 2100.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.")
            .Must(BeAValidDate)
            .WithMessage("Start date must be in the format yyyy-MM-dd.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.")
            .Must(BeAValidDate)
            .WithMessage("Start date must be in the format yyyy-MM-dd.")
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage("End date must be greater than or equal to  start date.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Location is required.")
            .MaximumLength(200)
            .WithMessage("Location cannot exceed 200 characters.");
    }

    private bool BeAValidDate(DateOnly date)
    {
        return date.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd");
    }
}


