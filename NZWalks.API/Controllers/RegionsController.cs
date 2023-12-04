using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private readonly IMapper _mapper;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionDomains = await _regionRepository.GetAllAsync();
            
            var regionDto = _mapper.Map<RegionDto>(regionDomains);  
            return Ok(regionDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id, string test)
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
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

                await _regionRepository.CreateAsync(regionDomainModel);


                return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
            }
            return BadRequest(ModelState);
            
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await _regionRepository.UpdateAsync(id,regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<Region>(regionDomainModel));
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
