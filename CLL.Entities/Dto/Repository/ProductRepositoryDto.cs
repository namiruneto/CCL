// <copyright file="ProductRepositoryDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Entities.Dto.Repository
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ProductRepositoryDto" />.
    /// </summary>
    public class ProductRepositoryDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Gets or sets the cantidad.
        /// </summary>
        public int cantidad { get; set; }
    }
}
