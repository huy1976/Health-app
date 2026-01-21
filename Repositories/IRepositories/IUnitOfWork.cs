namespace HealthyApp.Repositories.IRepositories;

public interface IUnitOfWork
{
    Task<bool> CompleteAsync();
}
