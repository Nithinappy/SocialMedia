
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;
[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;
    private readonly ILikeRepository _like;
    private readonly IHashTagRepository _hashtag;
    public PostController(ILogger<UserController> logger, IPostRepository post, IUserRepository user, ILikeRepository like, IHashTagRepository hashtag)
    {
        _logger = logger;
        _post = post;
        _user = user;
        _like = like;
        _hashtag = hashtag;
    }
    [HttpGet]
    public async Task<ActionResult<List<PostDTO>>> GetAllPosts()
    {
        var postsList = await _post.GetAllPosts();

        var dtoList = postsList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{post_id}")]
    public async Task<ActionResult<PostDTO>> GetPostById([FromRoute] long post_id)
    {
        PostDTO PostDTO = new PostDTO();
        var post = await _post.GetPostById(post_id);

        if (post is null)
            return NotFound("No User found with given User Id");

        PostDTO = post.asDto;

        PostDTO.PostCreatedBy  = (await _user.GetPostCreatedBy(post_id)).Select(x => x.asDto).ToList();
        PostDTO.PostLikes = (await _like.GetLikesById(post_id)).Select(x => x.asDto).ToList();
        PostDTO.HashTags = (await _hashtag.GetPostHashTagById(post_id)).Select(x => x.asDto).ToList();

        return Ok(PostDTO);
    }

    [HttpPost]
    public async Task<ActionResult<PostDTO>> CreatePost([FromBody] PostCreateDTO Data)
    {


        var toCreatePost = new Post
        {
            PostType = Data.PostType.Trim(),
            UserId = Data.UserId
        };

        var createdPost = await _post.CreatePost(toCreatePost);

        return StatusCode(StatusCodes.Status201Created, createdPost.asDto);
    }


    [HttpDelete("{post_id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] long post_id)
    {
        var existing = await _post.GetPostById(post_id);
        if (existing is null)
            return NotFound("No post found with given Post Id");

        var didDelete = await _post.DeletePost(post_id);

        return NoContent();
    }



}
