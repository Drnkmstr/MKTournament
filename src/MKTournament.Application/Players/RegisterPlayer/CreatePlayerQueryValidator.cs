using FluentValidation;
using MKTournament.Domain.Players;

namespace MKTournament.Application.Players.RegisterPlayer;

public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
{
    private const int MinPasswordLength = 8;
    private const int MaxPasswordLength = 50;
    
    public CreatePlayerCommandValidator()
    {
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage(PlayerMessages.PasswordNotEmpty)
            .Length(MinPasswordLength, MaxPasswordLength).WithMessage(string.Format(PlayerMessages.PasswordLength, MinPasswordLength, MaxPasswordLength))
            .Matches(@"[A-Z]+").WithMessage(PlayerMessages.PasswordAtLeastOneUpperCase)
            .Matches(@"[a-z]+").WithMessage(PlayerMessages.PasswordAtLeastOneLowerCase)
            .Matches(@"[0-9]+").WithMessage(PlayerMessages.PasswordAtLeatOneNumber)
            .Matches(@"[\!\?\*\.]+").WithMessage(string.Format(PlayerMessages.PasswordAtLeastOneSpecialChar, "(!? *.)"));

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage(PlayerMessages.EmailInvalid);

        RuleFor(c => c.NickName)
            .Length(PlayerNickName.MinLength, PlayerNickName.MaxLength).
            WithMessage(string.Format(PlayerMessages.NickNameLength, PlayerNickName.MinLength, PlayerNickName.MaxLength));
    }
}