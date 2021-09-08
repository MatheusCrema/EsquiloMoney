using System.Threading.Tasks;

using ApplicationCore.Interfaces.Repositories;




namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
         
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
