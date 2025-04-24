using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniUdemyWebAPI.Models;
using MiniUdemyWebAPI.Models.Authentication.Login;
using MiniUdemyWebAPI.Models.Authentication.SignUp;
using MiniUdemyWebAPI.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniUdemyWebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        //Registration
        [HttpPost("Registration")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {

            //Does user exists
            var userExists = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            //if not create idenity user from frombody data
            if (userExists == null)
            {
                IdentityUser user = new()
                {
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,
                    EmailConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),

                };

                //check does role exists
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (roleExists != null)
                {

                    var result = await _userManager.CreateAsync(user, registerUser.Password);

                    if (result.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(user, role);

                        //return a success message

                        return StatusCode(StatusCodes.Status201Created,
                              new Response
                              {
                                  Success = true,
                                  Status = "Success",
                                  Message = $"User created successfully !",
                                  StatusCode = 201
                              });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new Response
                            {
                                Status = "Error",
                                Message = "User creation Failed",
                                StatusCode = 500,
                                Success = false,
                                ErrorObject = result.Errors
                            });

                    }
                }
                else
                {
                    //show error for role
                    return StatusCode(StatusCodes.Status500InternalServerError,
                            new Response
                            {
                                Status = "Error",
                                Message = "Role Does not exists!"
                            });
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                             new Response
                             {
                                 Status = "Error",
                                 Message = "User creation Failed",
                                 StatusCode = 500,
                                 Success = false,

                             });

        }


        // Login endpoint
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // Check if the login model is null
            if (loginModel == null)
            {
                return BadRequest("Please enter credentials");
            }

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            // Check if the user exists and the password is correct
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                // Creating a list of claims for the authenticated user
                var authClaims = new List<Claim>
                     {
                            // Adding a claim for the user's email
                            new Claim(ClaimTypes.Email, user.Email),

                            // Adding a unique identifier (JTI) claim for the JWT token
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                // Retrieve the roles assigned to the user
                var userRoles = await _userManager.GetRolesAsync(user);

                // Add each role as a claim
                if (userRoles != null)
                {
                    foreach (var role in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                // Generate the JWT token using the claims
                var jwtToken = GetToken(authClaims);

                // Return the generated token and its expiration time
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo,
                });
            }

            // Return unauthorized if the user does not exist or the password is incorrect


            return StatusCode(StatusCodes.Status401Unauthorized,
             new Response
             {
                 Success = false,
                 Status = "Error",
                 Message = $"User {loginModel.Email} does not exist or you may have provided incorrect credentials.",
                 StatusCode = 401,
                 Title = "Unauthorized"
             });

        }


        // Method to generate a JWT token using the provided claims
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            // Create a symmetric security key using the secret key from configuration
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"], // The entity that issued the token (e.g., My application)
                audience: _configuration["JWT:ValidAudience"], // The intended recipient of the token (e.g., My API)
                expires: DateTime.Now.AddHours(1), // Set the token expiration time to 1 hour from now
                claims: authClaims, // Include the claims in the token
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256) // Sign the token using the HMAC SHA256 algorithm
            );

            // Return the generated token
            return token;
        }


    }
}
