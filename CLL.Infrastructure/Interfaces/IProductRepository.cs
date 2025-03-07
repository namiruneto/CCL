namespace CLL.Infrastructure.Interfaces
{
    using CLL.Entities.Dto.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IProductRepository" />.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// The ObtenerProductos.
        /// </summary>
        /// <returns>The <see cref="Task{List{ProductRepositoryDto}}"/>.</returns>
        Task<List<ProductRepositoryDto>> ObtenerProductos();

        /// <summary>
        /// The Agregar.
        /// </summary>
        /// <param name="cliente">The cliente<see cref="ProductRepositoryDto"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Agregar(ProductRepositoryDto cliente);

        /// <summary>
        /// The Actualizar.
        /// </summary>
        /// <param name="cliente">The cliente<see cref="ProductRepositoryDto"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Actualizar(ProductRepositoryDto cliente);
    }
}
