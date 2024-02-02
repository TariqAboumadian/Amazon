using Amazon.Application.Services;
using Amazon.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Amazon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IConfiguration _configration;
        public TestController(ICategoryService categoryService,IConfiguration configuration)
        {
            _CategoryService = categoryService;
            _configration = configuration;
        }
        [HttpGet("GetCategories")]
        [Authorize]
        public async Task<IActionResult> GetCategories(int items,int pagenumber)
        {
            var res=await _CategoryService.GetAllCategoryPagination(items,pagenumber);
            if(res is not null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrUpdateCategoryDTO model)
        {
            var res =await _CategoryService.Create(model);
            if(res is not null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetToken")]
        public  IActionResult GenerateToken()
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configration.GetSection("secretkey").Value);
            if (key.Length < 32)
            {
                throw new InvalidOperationException("JWT secret key size is insufficient for HMAC-SHA256.");
            }
            else
            {
                var tokendesc = new SecurityTokenDescriptor()
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,"Tariq"),
                    new Claim(ClaimTypes.Role,"Admin")
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                return Ok(tokenhandler.WriteToken(token));
            }

        }
    }
}
