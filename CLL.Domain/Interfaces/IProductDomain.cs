// <copyright file="IProductDomain.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Domain.Interfaces
{
    using CLL.Entities.Dto.Repository;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IProductDomain" />.
    /// </summary>
    public interface IProductDomain
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
