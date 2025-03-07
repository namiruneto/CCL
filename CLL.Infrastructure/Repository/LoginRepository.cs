namespace CLL.Infrastructure.Repository
{
    using CLL.Entities.Dto.Repository;
    using CLL.Infrastructure.Data;
    using CLL.Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="LoginRepository" />.
    /// </summary>
    public class LoginRepository : ILoginRepository
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/>.</param>
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<LoginRepositoryDto> ObtenerUsuario(string user, string password)
        {
            return await _context.usuarios
               .Where(x => x.username == user && x.password == password)
               .Select(x => new LoginRepositoryDto
               {
                   id = x.id,
                   username = x.username,
               })
               .FirstOrDefaultAsync();
        }
    }
}
