using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser user);
    }
}
