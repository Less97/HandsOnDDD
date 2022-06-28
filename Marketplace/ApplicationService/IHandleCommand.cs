namespace Marketplace.ApplicationService
{
    public interface IHandleCommand<in T>
    {
        Task Handle(T command);
    }
}
