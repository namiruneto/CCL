// <copyright file="LoginController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CCL.Server.Controllers
{
    using CLL.Application.Interfaces;
    using CLL.Entities.Dto.Request;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="LoginController" />.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        /// <summary>
        /// Defines the _authService.
        /// </summary>
        private readonly ILoginApplication _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="authService">Servicio de autenticación y registro de usuario.</param>
        public LoginController(ILoginApplication authService)
        {
            _authService = authService;
        }

        // POST: LoginController/Create

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="loginRequest">The loginRequest<see cref="LoginRequestDto"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Los datos de inicio de sesión son requeridos.");
            }

            var result = _authService.Login(loginRequest);
            if (result.Success)
            {
                return Ok(result);
            }
            return Unauthorized(result.Message);
        }
    }
}
