using System.Text.RegularExpressions;
using FluentValidation;
using TeamSync.Application.Interfaces;

namespace TeamSync.Application.Requests.Organisation;

/// <summary>
/// Defines the register command for organisation.
/// </summary>
public class OrganisationRegisterCommandValidator : AbstractValidator<OrganisationRegisterCommand>
{
    /// <summary>
    /// Specifies the databse context.
    /// </summary>
    private readonly ITeamSyncDbContext _teamSyncDbContext;

    /// <summary>
    /// Initializes a new instance of the validator.
    /// </summary>
    /// <param name="teamSyncDbContext"></param>
    public OrganisationRegisterCommandValidator(ITeamSyncDbContext teamSyncDbContext)
    {
        _teamSyncDbContext = teamSyncDbContext;
        Validate();
    }

    /// <summary>
    /// Performs various validations.
    /// </summary>
    private void Validate()
    {
        NotEmptyValidation();
        PatternValidation();
        ConflictValidation();
    }

    /// <summary>
    /// Validates if email is duplicate.
    /// </summary>
    private void ConflictValidation()
    {
        RuleFor(x => x.Email).Must(NotADuplicateEmail).WithMessage("'Email' is already in use.");
    }

    /// <summary>
    /// Performs duplicate check for email id
    /// </summary>
    /// <param name="email"></param>
    /// <returns>True if email id is not duplicate else false.</returns>
    private bool NotADuplicateEmail(string email)
    {
        return !_teamSyncDbContext.Users.Any(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    /// <summary>
    /// Validates not null and not empty.
    /// </summary>
    private void NotEmptyValidation()
    {
        RuleFor(o => o.Email).NotNull().NotEmpty()
            .WithMessage("'Email' cannot be empty.");
        RuleFor(o => o.Password).NotNull().NotEmpty()
            .WithMessage("'Password' cannot be empty.");
        RuleFor(o => o.Name).NotNull().NotEmpty()
            .WithMessage("'Name' cannot be empty.");
        RuleFor(o => o.IsDomainCheckEnabled).NotNull().NotEmpty()
            .WithMessage("'IsDomainCheckEnabled' cannot be empty.");
    }

    /// <summary>
    /// Validates pattern of data.
    /// </summary>
    private void PatternValidation()
    {
        var emailPattern = new Regex("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
        var passwordPattern = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
        var namePattern = new Regex("^[a-zA-Z0-9]+(?:[. ]+[a-zA-Z0-9]+)*$");

        RuleFor(o => o.Email).Must(x => emailPattern.IsMatch(x))
            .WithMessage("'Email' format is invalid.");
        RuleFor(o => o.Password).Must(x => passwordPattern.IsMatch(x))
            .WithMessage("'Password' should contain minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character.");
        RuleFor(o => o.Name).Must(x => namePattern.IsMatch(x))
            .WithMessage("'Name' should have only letters, numbers, spaces or periods.");
    }
}