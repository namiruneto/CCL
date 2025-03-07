// <copyright file="LoginApplication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Application.Services
{
    using CLL.Application.Handlers;
    using CLL.Application.Interfaces;
    using CLL.Domain.Interfaces;
    using CLL.Entities.Dto.Request;
    using CLL.Entities.Dto.Response;

    /// <summary>
    /// Defines the <see cref="LoginApplication" />.
    /// </summary>
    public class LoginApplication : ILoginApplication
    {
        /// <summary>
        /// Defines the _userDomain.
        /// </summary>
        private readonly Lazy<ILoginDomain> _userDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginApplication"/> class.
        /// </summary>
        /// <param name="userRepository">The userRepository<see cref="Lazy{ILoginDomain}"/>.</param>
        public LoginApplication(Lazy<ILoginDomain> userRepository)
        {
            _userDomain = userRepository;
        }

        /// <inheritdoc/>
        public ResponseDto Login(LoginRequestDto loginRequest)
        {
            var user = _userDomain.Value;

            PasswordHasher passwordHasher = new PasswordHasher();
            loginRequest.Password = passwordHasher.EncryptPassword(loginRequest.Password);
            if (!user.ValidatePassword(loginRequest))
            {
                return new ResponseDto { Success = false, Message = "Invalid username or password." };
            }

            TokenService tokenService = new TokenService();

            // Si las credenciales son correctas, devuelve el token o un mensaje de éxito
            return new ResponseDto
            {
                Success = true,
                Message = "Login successful",
                Token = tokenService.GenerateToken(loginRequest.Username),
            };
        }
    }
}
