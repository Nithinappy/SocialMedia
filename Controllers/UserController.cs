
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;
    private readonly ILikeRepository _like;
    public UserController(ILogger<UserController> logger, IUserRepository user,IPostRepository post,ILikeRepository like)
    {
        _logger = logger;
        _user = user;
        _post = post;
        _like=like;
    }
    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
    {
        var usersList = await _user.GetAllUsers();

        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{User_id}")]
    public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] long User_id)
    {
        UserDTO UserDTO = new UserDTO();
        var user = await _user.GetUserById(User_id);

        if (user is null)
            return NotFound("No User found with given User Id");

        UserDTO = user.asDto;
        UserDTO.MyPosts = (await _post.GetUserPostById(User_id)).Select(x => x.asDto).ToList();
        UserDTO.MyLikes = (await _like.GetUserLikesById(User_id)).Select(x => x.asDto).ToList();
      
        return Ok(UserDTO);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO Data)
    {


        var toCreateUser = new User
        {
            // first_name,last_name,user_name,email,mobile,bio,address,passcode
            FirstName = Data.FirstName.Trim(),
            LastName = Data.LastName.Trim(),
            UserName = Data.UserName.Trim(),
            Email = Data.Email.Trim().ToLower(),
            Mobile = Data.Mobile,
            Bio = Data.Bio.Trim(),
            Address = Data.Address,
            Passcode = Data.Passcode
        };

        var createdUser = await _user.CreateUser(toCreateUser);

        return StatusCode(StatusCodes.Status201Created, createdUser.asDto);
    }

    [HttpPut("{User_id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] long User_id,
    [FromBody] UserUpdateDTO Data)
    {
        var existing = await _user.GetUserById(User_id);
        if (existing is null)
            return NotFound("No User found with given User Id");

        var toUpdateUser = existing with
        {
            // FirstName = Data.FirstName?.Trim() ?? existing.LastName,
            // LastName = Data.LastName?.Trim() ?? existing.LastName,
            // Mobile = Data.Mobile ?? existing.Mobile,
            UserName = Data.UserName ?? existing.UserName,
            Address = Data.Address ?? existing.Address,
            Bio = Data.Bio ?? existing.Bio,
            Email = Data.Email ?? existing.Email

        };

        var didUpdate = await _user.UpdateUser(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }

    // [HttpDelete("{User_id}")]
    // public async Task<ActionResult> DeleteUser([FromRoute] long User_id)
    // {
    //     var existing = await _user.GetUserById(User_id);
    //     if (existing is null)
    //         return NotFound("No User found with given User Id");

    //     var didDelete = await _user.UpdateUser(User_id);

    //     return NoContent();
    // }



}
