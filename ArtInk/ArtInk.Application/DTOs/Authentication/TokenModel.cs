namespace ArtInk.Application.DTOs.Authentication;

public class TokenModel
{
    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}