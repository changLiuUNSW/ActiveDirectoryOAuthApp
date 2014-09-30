using System.Collections.Generic;
using DataAccess.Model.SiteModels;

namespace DataAccess.Service
{
    public interface ISiteService
    {
        IEnumerable<Site> All();
    }
}