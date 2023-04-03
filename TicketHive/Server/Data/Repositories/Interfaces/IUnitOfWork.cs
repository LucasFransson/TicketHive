namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
      
        int Complete();
    }
}
