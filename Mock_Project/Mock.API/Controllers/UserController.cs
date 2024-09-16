﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.UserService;
using Mock.Core.Models;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDTO loginDTO) 
        {
            User userFromDb = _userService.GetByUsername(loginDTO.Username);

            if (userFromDb == null)
            {
                return NotFound("User not found");
            }

            if (_userService.CheckPasswordCorrect(loginDTO.Password, userFromDb.Password!) == false)
            {
                return BadRequest("Incorrect Password");
            }

            if (userFromDb.IsActive == false)
            {
                return BadRequest("Sorry but this account is currently being locked");
            }

            string token = _userService.CreateToken(userFromDb);
            
            return Ok(new AuthResultDTO(token));
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            User userFromDb = _userService.GetByUsername(registerDTO.Username);

            if (_userService.GetByUsername(registerDTO.Username) != null)
            {
                return BadRequest("Username already exists");
            }

            if (_userService.GetAll().Any(x => x.Email == registerDTO.Email) == true)
            {
                return BadRequest("Email already exists");
            }

            if (_userService.GetAll().Any(x => x.Phone == registerDTO.Phone) == true)
            {
                return BadRequest("Phone Number already exists");
            }

            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                return BadRequest("Password and confirm password must match");
            }

            var newUser = new User();

            _mapper.Map(registerDTO, newUser);
            newUser.Password = _userService.HashPassword(newUser.Password);
            newUser.IsActive = true;
            newUser.IsAdmin = false;

            int result = _userService.Add(newUser);

            string token = _userService.CreateToken(newUser);

            if (result > 0)
            {
                return Ok(new AuthResultDTO(token)); 
            }
            else
            {
                return BadRequest("Register User Failed");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetCurrentUser(int id)
        {
            User userFromDb = _userService.GetByID(id);

            if (userFromDb == null) 
            {
                return NotFound();
            }

            return Ok(userFromDb);
        }
    }
}
