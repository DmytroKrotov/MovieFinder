using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace MovieFinder.Models
{
    public class User:IdentityUser<int>
    {
       

    }
}
