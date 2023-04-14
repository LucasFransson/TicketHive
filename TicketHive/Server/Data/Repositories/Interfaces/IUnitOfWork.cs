namespace TicketHive.Server.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICountryRepository Countries { get; set; }
        public IEventRepository Events { get; set; }
        public IEventTypeRepository EventTypes { get; set; }
        public ITicketRepository Tickets { get; set; }
        public ISoldTicketRepository SoldTickets { get; set; }

		Task CompleteAsync();

        void Dispose();
    }
}
