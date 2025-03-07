// <copyright file="ILoginDomain.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Domain.Interfaces
{
    using CLL.Entities.Dto.Request;

    /// <summary>
    /// Defines the <see cref="ILoginDomain" />.
    /// </summary>
    public interface ILoginDomain
    {
        /// <summary>
        /// The ValidatePassword.
        /// </summary>
        /// <param name="loginRequestDto">The loginRequestDto<see cref="LoginRequestDto"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool ValidatePassword(LoginRequestDto loginRequestDto);
    }
}
