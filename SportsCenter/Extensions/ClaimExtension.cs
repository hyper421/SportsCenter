using System.Security.Claims;

namespace SportsCenter.Extensions
{
    public static class ClaimExtension
    {
        public static string? GetMail(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email)?.Value;
        }

        public static int GetId(this ClaimsPrincipal user)
        {
            
            if (int.TryParse(user.FindFirst(ClaimTypes.Sid)?.Value,out int id))
            {
                return id;
            }
            else {
                throw new InvalidOperationException();
            }
             
        }
    }
}
