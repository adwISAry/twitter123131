using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterClone.Business.Dtos.AuthDtos;
using System.Threading.Tasks;
using TwitterClone.Business.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using TwitterClone.Core.Entities;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Business.Exceptions.Common;
using TwitterClone.Business.Exceptions.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text.Unicode;
using TwitterClone.Business.ExternalServices.Interfaces;

namespace TwitterClone.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        ITokenService _tokenService { get; }
        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService) 
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public AuthService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            AppUser? user = null;
            if(dto.UsernameOrEmail.Contains("@")) 
            {
                user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);

            }
            if (user == null) throw new UsernameOrPasswordWrongException();
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if(!result) throw new UsernameOrPasswordWrongException();
            return _tokenService.CreateToken(user);

        }
    }
}
