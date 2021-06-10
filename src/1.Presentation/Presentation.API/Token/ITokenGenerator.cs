using Application.DTO;

namespace Presentation.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserDTO userDTO);
    }
}