namespace CCL.Server.Controllers
{
    using CLL.Application.Interfaces;
    using CLL.Entities.Dto.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="ProductosController" />.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : Controller
    {
        /// <summary>
        /// Defines the _services.
        /// </summary>
        private readonly IProductApplication _services;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductosController"/> class.
        /// </summary>
        /// <param name="service">The service<see cref="IProductApplication"/>.</param>
        public ProductosController(IProductApplication service)
        {
            _services = service;
        }

        /// <summary>
        /// The inventario.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet("inventario")]
        public async Task<IActionResult> inventario()
        {
            var result = _services.Inventory();
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        /// <summary>
        /// The movimiento.
        /// </summary>
        /// <param name="product">The product<see cref="ProductRequestDto"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost("movimiento")]
        public async Task<IActionResult> movimiento(ProductRequestDto product)
        {
            var result = _services.Movimiento(product);
            if (result)
            {
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}
