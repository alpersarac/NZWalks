using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Globalization;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionDomains = await _regionRepository.GetAllAsync();
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
        public async Task<IActionResult> GetById([FromRoute]Guid id, string test)
        {
           var regionDomain = await _dbContext.Regions.FindAsync(id);
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = new Region
            {
                code = addRegionRequestDto.code,
                name = addRegionRequestDto.name,
                regionImageUrl = addRegionRequestDto.regionImageUrl
            };

            await _dbContext.AddAsync(regionDomainModel);
            await _dbContext.SaveChangesAsync();

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    code = regionDomainModel.code,
            //    name = regionDomainModel.name,
            //    regionImageUrl = regionDomainModel.regionImageUrl
            //};

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] UpdateRegionRequestDto updateRegionRequestDto,Guid id)
        {
            Region region = await _dbContext.Regions.FindAsync(id);
            if (region==null)
            {
                return NotFound();
            }
            region.name = updateRegionRequestDto.name;
            region.code = updateRegionRequestDto.code;
            region.regionImageUrl = updateRegionRequestDto.regionImageUrl;

            _dbContext.SaveChangesAsync();

            return Ok(region);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region region = _dbContext.Regions.Find(id);

            if (region==null)
            {
                return NotFound();
            }

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return Ok(region);
        }
    }
}
