namespace CLL.Infrastructure.Interfaces
{
    using CLL.Entities.Dto.Repository;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ILoginRepository" />.
    /// </summary>
    public interface ILoginRepository
    {
        /// <summary>
        /// The ObtenerUsuario.
        /// </summary>
        /// <param name="user">The user<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{LoginRepositoryDto}"/>.</returns>
        Task<LoginRepositoryDto> ObtenerUsuario(string user, string password);
    }
}
