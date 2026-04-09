using MediAssist.Api.Data.Entities;

public interface ITokenService
{
    string CreateToken(User user);
}