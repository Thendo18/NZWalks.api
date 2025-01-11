using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly IwalkRepository WalkRepository;

        public WalksController(IMapper mapper, IwalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.WalkRepository = walkRepository;
        }
        //create walk
        //Post:/api/walks

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walks>(addWalksRequestDto);

            await WalkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Get walks
        // https: portnumber/api/walks?filterOn?=Name&flterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pagesize=10
        [HttpGet]
        [ValidateModel]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery]
         bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize =  1000)
        {
            // get data from database - domain models 
            var walksDomainModel = await WalkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            //Map domains to DTO and Return DTOs
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        // Get region by ID
        // https: portnumber/api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var walks = dbContext
            // Map/convert Region Domain Model to Region DTO.walks.Find(id);
            // Get region domain
            var walksDomainModel = await WalkRepository.GetByIdAsync(id);

            if (walksDomainModel == null)
            {
                return NotFound();
            }
            //Map domains to DTO and Return DTOs
            return Ok(mapper.Map<WalkDto>(walksDomainModel));

        }

        //update 
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {

            // map domain model
            var walkDomainModel = mapper.Map<Walks>(updateWalkRequestDto);

            walkDomainModel = await WalkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //delete
        [HttpDelete]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await WalkRepository.DeleteAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Return deleted region back

            var walkDto = mapper.Map<RegionDto>(walkDomainModel);
            return Ok(walkDto);
        }
    }
}
