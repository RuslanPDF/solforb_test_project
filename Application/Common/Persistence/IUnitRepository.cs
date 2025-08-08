using Domain.Entities;

namespace Application.Common.Persistence;

public interface IUnitRepository : IRepository<UnitOfMeasurement>
{
    public Task<List<UnitOfMeasurement>> GetAllAsync(string status);
    public Task CreateUnit(UnitOfMeasurement unit);
    public Task<UnitOfMeasurement> GetByIdAsync(int id);
    public Task CheckNameExists(string name);
}