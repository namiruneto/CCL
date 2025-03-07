// <copyright file="LoginRepositoryDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Entities.Dto.Repository
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="LoginRepositoryDto" />.
    /// </summary>
    public class LoginRepositoryDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string password { get; set; }
    }
}
