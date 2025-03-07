// <copyright file="ILoginApplication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Application.Interfaces
{
    using CLL.Entities.Dto.Request;
    using CLL.Entities.Dto.Response;

    /// <summary>
    /// Defines the <see cref="ILoginApplication" />.
    /// </summary>
    public interface ILoginApplication
    {
        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="loginRequest">The loginRequest<see cref="LoginRequestDto"/>.</param>
        /// <returns>The <see cref="ResponseDto"/>.</returns>
        ResponseDto Login(LoginRequestDto loginRequest);
    }
}
