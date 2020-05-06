using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.DTO.Identity;
using BLL.Exceptions;
using BLL.Identity;
using BLL.Interfaces;
using BLL.Validation.User;
using DAL.Identity;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services
{
    class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RecrutingAgencyUserManager _userManager;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork, RecrutingAgencyUserManager userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetById(string id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user is null)
            {
                throw ExceptionBuilder.Create("User with such Id does not exist");
            }

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> Add(CreateUserDto userToAdd)
        {
            var validator = new CreateUserDtoValidation();
            var validationResult = await validator.ValidateAsync(userToAdd);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var mappedUser = _mapper.Map<CreateUserDto, User>(userToAdd);
            var result = await _userManager.CreateAsync(mappedUser, userToAdd.Password);
            if (!result.Succeeded)
            {
                throw ExceptionBuilder.Create("Error while creating user: " + result.ToString(),
                    HttpStatusCode.BadRequest);
            }
            return _mapper.Map<UserDto>(mappedUser);
        }

        public async Task Update(string id, UpdateUserDto userToUpdate)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user is null)
            {
                throw ExceptionBuilder.Create("User with such Id does not exist");
            }

            var validator = new UpdateUserDtoValidation();
            var validationResult = await validator.ValidateAsync(userToUpdate);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var mappedUser = _mapper.Map<UpdateUserDto, User>(userToUpdate);
            await _unitOfWork.Users.Update(mappedUser, id);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(string id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user is null)
            {
                throw ExceptionBuilder.Create("User with such Id does not exist");
            }
            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddUserToRole(string userId, string role)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user is null)
            {
                throw ExceptionBuilder.Create("User with such Id does not exist");
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw ExceptionBuilder.Create("Error while creating user: " + result.ToString(),
                    HttpStatusCode.BadRequest);
            }
        }
    }
}
