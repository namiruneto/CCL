// <copyright file="TokenService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Application.Services
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    /// <summary>
    /// Defines the <see cref="TokenService" />.
    /// </summary>
    internal class TokenService
    {
        /// <summary>
        /// The GenerateToken.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GenerateToken(string username)
        {
            string va = Environment.GetEnvironmentVariable("MySecretKey");
            var symmetricKey = new SymmetricSecurityKey(Convert.FromBase64String(Environment.GetEnvironmentVariable("MySecretKey")));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                issuer: "BackEnd",
                audience: "FrontEnd",
                claims: claims,
                expires: DateTime.Now.AddMinutes(11),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// The ValidateToken.
        /// </summary>
        /// <param name="token">The token<see cref="string"/>.</param>
        /// <returns>The <see cref="ClaimsPrincipal"/>.</returns>
        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Environment.GetEnvironmentVariable("MySecretKey"))),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            return tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        }
    }
}
