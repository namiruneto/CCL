namespace CLL.Application.Interfaces
{
    using CLL.Entities.Dto.Repository;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IProductApplication" />.
    /// </summary>
    public interface IProductApplication
    {
        /// <summary>
        /// The Inventory.
        /// </summary>
        /// <returns>The <see cref="List{ProductRepositoryDto}"/>.</returns>
        List<ProductRepositoryDto> Inventory();

        /// <summary>
        /// The Movimiento.
        /// </summary>
        /// <param name="product">The product<see cref="ProductRepositoryDto"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool Movimiento(ProductRepositoryDto product);
    }
}
