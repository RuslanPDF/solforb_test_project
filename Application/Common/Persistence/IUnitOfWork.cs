namespace Application.Common.Persistence;

public interface IUnitOfWork
{
    public TRepository GetRepository<TRepository>() where TRepository: IRepository;
    public Task CommitAsync(CancellationToken cancellationToken = default); 
}