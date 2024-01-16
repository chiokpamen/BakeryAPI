using BakeryAPI.Models;

namespace BakeryAPI.Repositories
{
    public interface IBakeryRepository
    {
        Task<IEnumerable<Pastry>> Get();
        Task<Pastry> Get(int PastryId);
        Task<Pastry> Create (Pastry pastry);
        Task<Pastry> Update (Pastry pastry);
        Task Delete (int PastryId);
    }
}
