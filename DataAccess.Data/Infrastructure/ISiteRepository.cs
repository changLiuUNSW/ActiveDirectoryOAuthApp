using System.Linq;
using DataAccess.Model.SiteModels;

namespace DataAccess.Data.Infrastructure
{
    public interface ISiteRepository : IRepository<Site>
    {
        IQueryable<Site> GetAvailableCalls(int days, string zone = null, string region = null, string state = null);
    }
}
