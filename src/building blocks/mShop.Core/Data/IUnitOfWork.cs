using System.Threading.Tasks;

namespace mShop.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
