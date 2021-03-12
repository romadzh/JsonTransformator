using Consist.JsonTransformator.BL.DomainObjects;

namespace Consist.JsonTransformator.BL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string GetToken(AuthenticateDto authenticateDto);
    }
}
