using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddWalkRequestDto addWalkRequestDto)
        {
            var walkRegionModel = _mapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(walkRegionModel);

            return Ok(_mapper.Map<WalkDto>(walkRegionModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var walkRegionModel = await _walkRepository.GetAllAsync();

            return Ok(_mapper.Map<WalkDto>(walkRegionModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkModel = _walkRepository.GetByIdAsync(id);
            if (walkModel==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkModel));    
        }
        [HttpPut]
        [Route("id:Guid")]
        public async Task<IActionResult> Update([FromRoute]Guid id,UpdateRegionRequestDto updateRegionRequestDto)
        {
            var walkDto = _mapper.Map<Walk>(updateRegionRequestDto);

            walkDto = await _walkRepository.UpdateAsync(id,walkDto);

            if (walkDto!=null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDto));
        }
        [HttpDelete]
        [Route("id:Guid")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedWalk = await _walkRepository.DeleteAsync(id);
            if (deletedWalk!=null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(deletedWalk));
        }

    }
}
