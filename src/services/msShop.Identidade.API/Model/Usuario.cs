using Microsoft.AspNetCore.Identity;

namespace msShop.Identidade.API.Model
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
