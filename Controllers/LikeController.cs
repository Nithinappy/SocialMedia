
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;
[ApiController]
[Route("api/likes")]
public class LikeController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;
    private readonly ILikeRepository _like;
    public LikeController(ILogger<UserController> logger, IPostRepository post, IUserRepository user, ILikeRepository like)
    {
        _logger = logger;
        _post = post;
        _user = user;
        _like = like;
    }


    [HttpPost]
    public async Task<ActionResult<LikeDTO>> CreatePost([FromBody] LikeCreateDTO Data)
    {


        var toCreateLike = new Like
        {
          PostId=Data.PostId,
          UserId = Data.UserId
        };

        var createdLike = await _like.CreateLike(toCreateLike);

        return StatusCode(StatusCodes.Status201Created, createdLike.asDto);
    }


    [HttpDelete("{like_id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] long like_id)
    {
        var existing = await _like.GetLikeById(like_id);
        if (existing is null)
            return NotFound("No Likes found with given Like Id");

        var didDelete = await _like.DeleteLike(like_id);

        return NoContent();
    }



}
