using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using ServiceStack.DataAnnotations;
using System.Runtime.InteropServices;

namespace NZWalks.API.Controllers
{
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]  //API controller attribute
    //[Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // get data from databse - domain models 
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map domains to DTO and Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // Get region by ID
        // https: portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var regions = dbContext
            // Map/convert Region Domain Model to Region DTO.Regions.Find(id);
            // Get region domain
            var regionsDomain = await regionRepository.GetByIdAsync(id);

            if (regionsDomain == null)
            {
                return NotFound();
            }
            //Map domains to DTO and Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));

        }

        // https: portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        { 
            // Map/convert AddRegionRequestDto to Region (Domain Model)
            var regionDomainModel = mapper.Map<Regions>(addRegionRequestDto);

            // Use domain model to create a region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map the created region back to DTO (optional)
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            // Return a 201 Created response with the newly created resource
            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
          
        }
        // https: portnumber/api/regions/{id}
        //update 
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            // map domain model
            var regionDomainModel = mapper.Map<Regions>(updateRegionRequestDto);

           regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        // https: portnumber/api/regions/{id}
        //delete
        [HttpDelete]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Return deleted region back

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }

    }
}
