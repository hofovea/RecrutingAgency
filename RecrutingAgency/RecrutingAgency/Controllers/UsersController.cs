using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.Identity;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitingAgency.Errors;
using RecruitingAgency.Models.User;

namespace RecruitingAgency.Controllers
{
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        //GET ALL
        // GET: api/users
        [HttpGet]
        [Authorize(Roles = "Admins")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserModel>> Get()
        {
            var usersDtos = await _userService.GetAll();
            var res = _mapper.Map<IEnumerable<UserModel>>(usersDtos);
            return Ok(res);
        }

        //GET BY ID
        //GET: api/users/{id}
        [HttpGet("id")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserModel>> Get(string id)
        {
            var user = await _userService.GetById(id);
            var result = _mapper.Map<UserModel>(user);
            return Ok(result);
        }

        //CREATE
        // POST: api/users
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserModel>> Post([FromBody] CreateUserDto userBody)
        {
            var user = await _userService.Add(userBody);
            var result = _mapper.Map<UserModel>(user);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        //UPDATE
        // PUT: api/users/{id}
        [HttpPut("{id}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(string id, [FromBody] UpdateUserDto user)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userService.GetById(currentUserId);
            if (currentUser.Id != id) 
                return Forbid();
            if (!User.IsInRole("Admins")) 
                return Forbid();

            await _userService.Update(id, user);
            return NoContent();
        }

        //DELETE
        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admins")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
