// <copyright file="PasswordHasher.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CLL.Application.Handlers
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="PasswordHasher" />.
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// The EncryptPassword.
        /// </summary>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string EncryptPassword(string password)
        {
            // Convertir la contraseña a un array de bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Crear una instancia del algoritmo de hash SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Obtener el hash de la contraseña
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convertir el hash a una cadena Base64
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
