namespace Marketplace.ApplicationService
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
