namespace BoatRentalSystem.Core.Interfaces
{
    using BoatRentalSystem.Core.Entities;

    public interface IAdditionRepository
    {
        Task<IEnumerable<Addition>>GetAllAdditions();
        Task<Addition> GetAdditionById(int id);
        Task AddAddition(Addition addition);
        Task UpdateAddition(Addition addition);
        Task DeleteAddition(int id);
    }
}
