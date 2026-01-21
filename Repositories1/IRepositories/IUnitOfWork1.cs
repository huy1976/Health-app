namespace HealthyApp.Repositories.IRepositories;

public interface IUnitOfWork1
{
    Task<bool> CompleteAsync();
}
