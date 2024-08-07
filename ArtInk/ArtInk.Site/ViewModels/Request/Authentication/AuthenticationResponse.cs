namespace ArtInk.Site.ViewModels.Request.Authentication;

public class AuthenticationResponse
{
    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public bool Success { get; set; }
    
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}