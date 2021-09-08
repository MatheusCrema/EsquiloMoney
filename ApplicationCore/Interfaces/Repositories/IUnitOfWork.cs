using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
