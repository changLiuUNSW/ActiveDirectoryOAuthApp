using System.Collections.Generic;
using DataAccess.Data.Infrastructure;
using DataAccess.Model.SiteModels;

namespace DataAccess.Service
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _repository;

        public SiteService(ISiteRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Site> All()
        {
            return _repository.GetAll();


//            var result = _repository.().Select(x => new
//            {
//                x.Name,
//                Qc = x.Sales_Rep,
//                Zone = x.Sales_Pref
//            });
//
//            foreach (var record in result)
//            {
//                yield return new RecordViewModel
//                {
//                    Name = record.Name,
//                    Qc = record.Qc,
//                    Zone = record.Zone
//                };
//            }
        }
    }
}