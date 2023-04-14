using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketHive.Server.Models;

namespace TicketHive.Server.Data.Databases
{
    public class UserDbContext : ApiAuthorizationDbContext<UserModel>
    {
        public UserDbContext(
            DbContextOptions<UserDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
	}
}