namespace CLL.Infrastructure.Repository
{
    using CLL.Entities.Dto.Repository;
    using CLL.Infrastructure.Data;
    using CLL.Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ProductRepository" />.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/>.</param>
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<List<ProductRepositoryDto>> ObtenerProductos()
        {
            return await _context.productos.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task Agregar(ProductRepositoryDto cliente)
        {
            _context.productos.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task Actualizar(ProductRepositoryDto cliente)
        {
            _context.productos.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
