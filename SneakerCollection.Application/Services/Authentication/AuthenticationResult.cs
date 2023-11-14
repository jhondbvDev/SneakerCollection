using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Services.Authentication
{
    public record AuthenticationResult
 (
     Guid Id,
     string Email,
     string Token);
}
