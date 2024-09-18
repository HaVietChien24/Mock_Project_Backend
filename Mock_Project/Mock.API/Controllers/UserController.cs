using AutoMapper;
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
            try
            {
                User userFromDb = _userService.GetByUsername(loginDTO.Username);

                if (userFromDb == null)
                {
                    return BadRequest(new AuthResultDTO(null, "Incorrect credentials"));
                }

                bool isPasswordCorrect = _userService.CheckPasswordCorrect(loginDTO.Password, userFromDb.Password!);

                if (isPasswordCorrect == false)
                {
                    return BadRequest(new AuthResultDTO(null, "Incorrect credentials"));
                }

                if (userFromDb.IsActive == false)
                {
                    return BadRequest(new AuthResultDTO(null, "Sorry but this account is currently being locked"));
                }

                string token = _userService.CreateToken(userFromDb);

                return Ok(new AuthResultDTO(token, null));
            }
            catch (Exception ex) 
            {
                return BadRequest(new AuthResultDTO(null, ex.Message));
            }
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            try
            {
                if (_userService.GetByUsername(registerDTO.Username) != null)
                {
                    return BadRequest(new AuthResultDTO(null, "Username already exists"));
                }

                if (_userService.GetAll().Any(x => x.Email == registerDTO.Email) == true && registerDTO.Email != "")
                {
                    return BadRequest(new AuthResultDTO(null, "Email already exists"));
                }

                if (_userService.GetAll().Any(x => x.Phone == registerDTO.Phone) == true && registerDTO.Phone != "")
                {
                    return BadRequest(new AuthResultDTO(null, "Phone Number already exists"));
                }

                if (registerDTO.Password != registerDTO.ConfirmPassword)
                {
                    return BadRequest(new AuthResultDTO(null, "Password and confirm password must match"));
                }

                if (registerDTO.Email == "" && registerDTO.Phone == "")
                {
                    return BadRequest(new AuthResultDTO(null, "You need to at least enter either you email or phone number"));
                }

                var newUser = new User();

                _mapper.Map(registerDTO, newUser);
                newUser.Password = _userService.HashPassword(newUser.Password);
                newUser.IsActive = true;
                newUser.IsAdmin = false;

                int result = _userService.Add(newUser);

                if (result > 0)
                {
                    return Ok(new AuthResultDTO(null, null));
                }
                else
                {
                    return BadRequest(new AuthResultDTO(null, "Register User Failed"));
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(new AuthResultDTO(null, ex.Message));
            }
        }


        [HttpPut("updateProfile")]
        [AllowAnonymous]
        public IActionResult UpdateProfile(UpdateProfileDTO updateProfileDTO)
        {
            try
            {
                User userToUpdate = _userService.GetByUsername(updateProfileDTO.Username);

                if (userToUpdate == null)
                {
                    return BadRequest(new AuthResultDTO(null, "Username doesn't exists"));
                }

                if (_userService.GetAll().Any(x => x.Email == updateProfileDTO.Email)
                    && updateProfileDTO.Email != userToUpdate.Email
                    && updateProfileDTO.Email != "")
                {
                    return BadRequest(new AuthResultDTO(null, "Email already exists"));
                }

                if (_userService.GetAll().Any(x => x.Phone == updateProfileDTO.Phone)
                    && updateProfileDTO.Phone != userToUpdate.Phone
                    && updateProfileDTO.Phone != "")
                {
                    return BadRequest(new AuthResultDTO(null, "Phone Number already exists"));
                }

                if (updateProfileDTO.Email == "" && updateProfileDTO.Phone == "")
                {
                    return BadRequest(new AuthResultDTO(null, "You need to at least enter either you email or phone number"));
                }

                _mapper.Map(updateProfileDTO, userToUpdate);

                int result = _userService.Update(userToUpdate);

                string token = _userService.CreateToken(userToUpdate);

                if (result > 0)
                {
                    return Ok(new AuthResultDTO(token, "Update Profile Successfully"));
                }
                else
                {
                    return BadRequest(new AuthResultDTO(null, "Register User Failed"));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new AuthResultDTO(null, ex.Message));
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetCurrentUser(int id)
        {
            User userFromDb = _userService.GetByID(id, "Borrowings");

            if (userFromDb == null)
            {
                return NotFound();
            }

            return Ok(userFromDb);
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result = _userService.GetAllUser();
            return Ok(result);
        }

        [HttpPut("BanAccount/{userId}")]
        public IActionResult BanAcount(int userId)
        {
            bool result = _userService.BanAccount(userId);
            if (result)
            {
                return Ok("Update success");
            }
            else
            {
                return NotFound("User not found");
            }
        }
    }
}
