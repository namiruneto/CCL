// <copyright file="ProductDomain.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Domain.Services
{
    using CLL.Domain.Interfaces;
    using CLL.Entities.Dto.Repository;
    using CLL.Infrastructure.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ProductDomain" />.
    /// </summary>
    public class ProductDomain : IProductDomain
    {
        /// <summary>
        /// Defines the _clienteRepository.
        /// </summary>
        private readonly Lazy<IProductRepository> _clienteRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDomain"/> class.
        /// </summary>
        /// <param name="clienteRepository">The clienteRepository<see cref="Lazy{ILoginRepository}"/>.</param>
        public ProductDomain(Lazy<IProductRepository> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <inheritdoc/>
        public List<ProductRepositoryDto> Inventory()
        {
            return _clienteRepository.Value.ObtenerProductos().Result;
        }

        /// <inheritdoc/>
        public bool Movimiento(ProductRepositoryDto product)
        {
            if (product.id == 0)
            {
                _clienteRepository.Value.Agregar(product);
            }
            else
            {
                _clienteRepository.Value.Actualizar(product);
            }

            return true;
        }
    }
}
