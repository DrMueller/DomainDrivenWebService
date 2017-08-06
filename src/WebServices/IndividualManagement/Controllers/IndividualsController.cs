﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Ddws.Application.IndividualManagement.Dtos;
using Mmu.Ddws.Application.IndividualManagement.Services;

namespace Mmu.Ddws.WebServices.IndividualManagement.Controllers
{
    [Route("api/[controller]")]
    public class IndividualsController : Controller
    {
        private readonly IIndividualSearchService _individualSearchService;
        private readonly IIndividualUpdateService _individualUpdateService;

        public IndividualsController(IIndividualUpdateService individualUpdateService, IIndividualSearchService individualSearchService)
        {
            _individualUpdateService = individualUpdateService;
            _individualSearchService = individualSearchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndividuals()
        {
            var result = await _individualSearchService.SearchAllAsync();
            return Ok(result);
        }

        [HttpGet("Test")]
        public IActionResult GetTestIndividual()
        {
            var result = new IndividualDto
            {
                FirstName = "Matthias",
                Gender = IndividualGenderDto.Male,
                Id = "Tra124",
                LastName = "Müller"
            };

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutIndividualAsync([FromBody] IndividualDto individualDto)
        {
            var result = await _individualUpdateService.SaveIndividualAsync(individualDto);
            return Ok(result);
        }
    }
}