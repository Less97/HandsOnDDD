namespace Marketplace.ApplicationService
{
    public interface IEntityStore
    {
        Task<T> Load<T>(string id);
        Task Save<T>(T entity);
        Task<bool> Exists<T>(string entityId);
    }

    public class RavenDbEntityStore : IEntityStore
    {
        public Task<T> Load<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task Save<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists<T>(string entityId)
        {
            throw new NotImplementedException();
        }
    }
}
