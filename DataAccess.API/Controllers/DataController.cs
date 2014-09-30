using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using DataAccess.Model.SiteModels;
using DataAccess.Service;
using ResourceMetadata.API.ViewModels;

namespace ResourceMetadata.API.Controllers
{
    [RoutePrefix("api/Data")]
    public class DataController : ApiController
    {
        private readonly ISiteService siteService;

        public DataController(ISiteService siteService)
        {
            this.siteService = siteService;
        }

        [Authorize]
        [Route("")]
        // GET api/Data
        public IHttpActionResult Get()
        {
            IEnumerable<Site> sites = siteService.All();
            IList<SiteViewModel> siteViewModel = new List<SiteViewModel>();
            Mapper.Map(sites, siteViewModel);
            return Ok(siteViewModel);
        }

        // GET api/Data/5
        public SiteViewModel Get(int id)
        {
            return null;
        }
    }
}