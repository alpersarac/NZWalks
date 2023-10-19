using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regionDomains = _dbContext.Regions.ToList();
            List<RegionDto> regions = new List<RegionDto>();
            foreach (var regionDomain in regionDomains)
            {
                regions.Add(new RegionDto
                {
                    Id = regionDomain.Id,
                    code = regionDomain.code,
                    name = regionDomain.name,
                    regionImageUrl = regionDomain.regionImageUrl
                });
                
            }
            return Ok(regions);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id, string test)
        {
           var regionDomain = _dbContext.Regions.Find(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            RegionDto regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                code = regionDomain.code,
                name = regionDomain.name,
                regionImageUrl = regionDomain.regionImageUrl
            };

            return Ok(regionDomain);
        }
    }
}
