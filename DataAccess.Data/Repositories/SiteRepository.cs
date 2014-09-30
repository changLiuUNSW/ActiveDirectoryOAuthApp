using System;
using System.Linq;
using DataAccess.Data.Infrastructure;
using DataAccess.Model.SiteModels;

namespace DataAccess.Data.Repositories
{
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        public SiteRepository(IDatabaseFactory dBContext) : base(dBContext)
        {
        }

        //no longer get zone / region from database
        //get region / zone from xml file instead in logic layer
        /*public SysInfo GetSysInfo
        {
            get
            {
                //convert IQueryable to list because we do not want to deferred sql here                
                var zones = SearchFor(x => x.Sales_Pref != null)
                    .Select(x => new {zone = x.Sales_Pref})
                    .Distinct()
                    .ToList();

                var sortedZones = zones.OrderBy(x => x.zone);

                var regions = SearchFor(x => x.Sales_Box != null)
                    .Select(x=>new {region = x.Sales_Box})
                    .Distinct()
                    .ToList();

                var sortedRegion = regions.OrderBy(x => x.region);


                var sysInfo = new SysInfo {Regions = new List<string>(), Zones = new List<string>()};

                foreach (var row in sortedZones)
                {
                    if (!String.IsNullOrEmpty(row.zone))
                        sysInfo.Zones.Add(row.zone);
                }

                foreach (var row in sortedRegion)
                {
                    if (!string.IsNullOrEmpty(row.region))
                        sysInfo.Regions.Add(row.region);;
                }

                return sysInfo;
            }
        }*/

        /// <summary>
        ///     return application-wide information such as zone / region code
        /// </summary>
        /// <summary>
        ///     return a collection of site that has valid next call day
        /// </summary>
        /// <returns>return is icollection</returns>
        public IQueryable<Site> GetAvailableCalls(int days, string zone = "", string region = "", string state = "")
        {
            DateTime nextDate = DateTime.Now.AddDays(days);

            IQueryable<Site> result = Query(x => x.Contacts.Any(y => y.NextCall != null && y.NextCall > nextDate));

            if (!String.IsNullOrEmpty(zone))
            {
                result = result.Where(x => x.Sales_Pref == zone);

                //only apply filter to region when there is zone available
                if (!String.IsNullOrEmpty(region))
                    result = result.Where(x => x.Sales_Box == region);
            }

            if (!string.IsNullOrEmpty(state))
            {
                result = result.Where(x => x.Address.State == state);
            }

            return result;
        }
    }
}