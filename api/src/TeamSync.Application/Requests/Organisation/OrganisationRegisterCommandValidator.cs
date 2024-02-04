using System.Text.RegularExpressions;
using FluentValidation;
using TeamSync.Application.Interfaces;

namespace TeamSync.Application.Requests.Organisation;

/// <summary>
/// Defines the register command for organisation.
/// </summary>
public class OrganisationRegisterCommandValidator : AbstractValidator<OrganisationRegisterCommand>
{
    private readonly ITeamSyncDbContext _teamSyncDbContext;
    public OrganisationRegisterCommandValidator(ITeamSyncDbContext teamSyncDbContext)
    {
        _teamSyncDbContext = teamSyncDbContext;
        Validate();
    }


    private void Validate()
    {
        var emailPattern = new Regex("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
        var passwordPattern = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$");
        var namePattern = new Regex("[a-zA-Z0-9]+(?:[. ]+[a-zA-Z0-9]+)*");

        RuleFor(o => o.Email).Must(x => emailPattern.IsMatch(x)).WithMessage("Invalid email format.");
        RuleFor(o => o.Password).Must(x => passwordPattern.IsMatch(x)).WithMessage("Password should contain minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character.");
        RuleFor(o => o.Name).Must(x => namePattern.IsMatch(x)).WithMessage("Name should have only letters, numbers, spaces or periods.");

    }
}