﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
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
        [ValidateModel]
        public async Task<IActionResult> Create(AddWalkRequestDto addWalkRequestDto)
        {
            var walkRegionModel = _mapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(walkRegionModel);

            return Ok(_mapper.Map<WalkDto>(walkRegionModel));
        }
        //Get: api/walks?filterOn=Name&filterQuery=track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        [Route("api/walks")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber=1, [FromQuery] int pageSize=1000)
        {

            var walkRegionModel = await _walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending??true,pageNumber,pageSize);

            return Ok(_mapper.Map<WalkDto>(walkRegionModel));
        }
        [HttpGet]
        [Route("id:Guid")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walkModel = _walkRepository.GetByIdAsync(id);
            if (walkModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkModel));
        }
        [HttpPut]
        [Route("id:Guid")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {

            var walkDto = _mapper.Map<Walk>(updateWalkRequestDto);

            walkDto = await _walkRepository.UpdateAsync(id, walkDto);

            if (walkDto != null)
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
            if (deletedWalk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(deletedWalk));
        }

    }
}
