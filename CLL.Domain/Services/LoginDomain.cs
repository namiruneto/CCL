// <copyright file="LoginDomain.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Domain.Services
{
    using CLL.Domain.Interfaces;
    using CLL.Entities.Dto.Request;
    using CLL.Infrastructure.Interfaces;

    /// <summary>
    /// Defines the <see cref="LoginDomain" />.
    /// </summary>
    public class LoginDomain : ILoginDomain
    {
        /// <summary>
        /// Defines the _clienteRepository.
        /// </summary>
        private readonly Lazy<ILoginRepository> _clienteRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginDomain"/> class.
        /// </summary>
        /// <param name="clienteRepository">The clienteRepository<see cref="Lazy{ILoginRepository}"/>.</param>
        public LoginDomain(Lazy<ILoginRepository> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <inheritdoc/>
        public bool ValidatePassword(LoginRequestDto loginRequestDto)
        {
            var loginRepository = _clienteRepository.Value;
            return loginRepository.ObtenerUsuario(loginRequestDto.Username, loginRequestDto.Password).Result != null;
        }
    }
}
