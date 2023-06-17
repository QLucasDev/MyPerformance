using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using API.Models;
using API.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IHash _hash;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private EmailChecker _mailChecker = new EmailChecker();

        public LoginController(IJwtProvider jwtProvider, IHash hash, IRepositoryWrapper repository, IMapper mapper)
        {
            _jwtProvider = jwtProvider;
            _hash = hash;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                if (userLogin is null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = await _repository.User.GetUserByEmail(userLogin.Email);
                var password = _hash.Compare(userLogin.Password, user.Password);

                if (user is null)
                {
                    return NotFound();
                }

                if (user.Email.Equals(userLogin.Email) && password)
                {
                    //Console.WriteLine("Senha: " + user.Password);
                    var _claim = new List<Claim>
                    {
                        new Claim("ClaimId", user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name)
                    };

                    AuthenticatedResponse token = _jwtProvider.GetToken(_claim);

                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegister)
        {
            try
            {

                if (userRegister is null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!_mailChecker.IsEmailValid(userRegister.Email))
                {
                    return BadRequest("Insira um Email válido.");
                }

                var userCheck = await _repository.User.GetUserByEmail(userRegister.Email);
                if (userCheck != null)
                {
                    if (userRegister.Email == userCheck.Email)
                    {
                        return Conflict("Email já cadastrado");
                    }
                }

                var encryptedPassword = _hash.Encrypt(userRegister.Password);

                var user = _mapper.Map<User>(userRegister);
                user.Password = encryptedPassword;

                _repository.User.CreateUser(user);
                await _repository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}