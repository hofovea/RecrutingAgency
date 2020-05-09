using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.JobPosting;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RecruitingAgency.Errors;
using RecruitingAgency.Models.JobPosting;

namespace RecruitingAgency.Controllers
{
    public class JobPostingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobPostingService _jobPostingService;
        private readonly IAuthorizationService _authorizationService;

        public JobPostingsController(IMapper mapper, IJobPostingService jobPostingService, IAuthorizationService authorizationService)
        {
            _mapper = mapper;
            _jobPostingService = jobPostingService;
            _authorizationService = authorizationService;
        }

        //GET ALL
        //GET: api/jobpostings
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<JobPostingModel>>> Get()
        {
            var jobs = await _jobPostingService.GetAll();
            var res = _mapper.Map<IEnumerable<JobPostingDto>, IEnumerable<JobPostingModel>>(jobs);
            return Ok(res);
        }

        //GET BY ID
        //GET: api/jobpostings/{id}
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JobPostingModel>> Get(int id)
        {
            var jobDto = await _jobPostingService.GetById(id);
            var res = _mapper.Map<JobPostingDto, JobPostingModel>(jobDto);
            return Ok(res);
        }

        //CREATE
        //POST: api/jobpostings
        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<JobPostingModel>>> Post([FromBody] CreateJobPostingDto postBody)
        {
            var jobBodyDto = _mapper.Map<CreateJobPostingDto>(postBody);
            var job = await _jobPostingService.Add(jobBodyDto);
            var res = _mapper.Map<JobPostingModel>(job);
            return CreatedAtAction(nameof(Get), new {id = res.Id}, res);
        }

        //UPDATE
        //POST: api/jobpostings/{id}
        [HttpPost]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(int id, [FromBody] UpdateJobPostingDto postBody)
        {
            if (!(await _authorizationService.AuthorizeAsync(User, id, "EditJob")).Succeeded)
            {
                return Forbid();
            }

            await _jobPostingService.Update(id, postBody);
            return NoContent();
        }

        //DELETE
        // DELETE: api/posts/{id}
        [HttpDelete("{id}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var job = await _jobPostingService.GetById(id);
            if (!(await _authorizationService.AuthorizeAsync(User, id, "DeleteJob")).Succeeded)
            {
                return Forbid();
            }

            await _jobPostingService.Delete(id);
            return NoContent();
        }
    }
}