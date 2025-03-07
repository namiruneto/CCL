// <copyright file="ProductApplication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Application.Services
{
    using CLL.Application.Interfaces;
    using CLL.Domain.Interfaces;
    using CLL.Entities.Dto.Repository;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ProductApplication" />.
    /// </summary>
    public class ProductApplication : IProductApplication
    {
        /// <summary>
        /// Defines the _domain.
        /// </summary>
        private readonly Lazy<IProductDomain> _domain;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApplication"/> class.
        /// </summary>
        /// <param name="domain">The domain<see cref="Lazy{IProductDomain}"/>.</param>
        public ProductApplication(Lazy<IProductDomain> domain)
        {
            _domain = domain;
        }

        /// <inheritdoc/>
        public List<ProductRepositoryDto> Inventory()
        {
            return _domain.Value.Inventory();
        }

        /// <inheritdoc/>
        public bool Movimiento(ProductRepositoryDto product)
        {
            return _domain.Value.Movimiento(product);
        }
    }
}
