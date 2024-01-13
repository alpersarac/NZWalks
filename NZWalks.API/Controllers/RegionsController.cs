using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Globalization;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionsController> _logger;

        public RegionsController(NZWalksDbContext dbContext, 
            IRegionRepository regionRepository,
            IMapper mapper,
            ILogger<RegionsController> logger)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        //GET:/ api/walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            _logger.LogInformation("GetAll Regions Action method was invoked");
            _logger.LogWarning("Warning error");
            _logger.LogError("Error log");
            var regionDomains = await _regionRepository.GetAllAsync();

            _logger.LogInformation($"Finished GetAll Regions Action method was invoked {JsonSerializer.Serialize(regionDomains)}");
            
            var regionDto = _mapper.Map<List<RegionDto>>(regionDomains);
            return Ok(regionDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string test)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            RegionDto regionDto = _mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            await _regionRepository.CreateAsync(regionDomainModel);


            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);

        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Region>(regionDomainModel));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region region = _dbContext.Regions.Find(id);

            if (region == null)
            {
                return NotFound();
            }

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return Ok(region);
        }
    }
}
