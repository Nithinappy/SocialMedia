
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;
[ApiController]
[Route("api/hashtags")]
public class HashTagController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;
    private readonly IHashTagRepository _hashtag;
    public HashTagController(ILogger<UserController> logger, IPostRepository post, IUserRepository user, IHashTagRepository hashtag)
    {
        _logger = logger;
        _post = post;
        _user = user;
        _hashtag = hashtag;
    }


    [HttpPost]
    public async Task<ActionResult<HashTagDTO>> CreatePost([FromBody] HashTagCreateDTO Data)
    {


        var toCreateHashTag = new HashTag
        {
         HashName = Data.HashName.Trim()
        };

        var createdHashTag = await _hashtag.CreateHashTag(toCreateHashTag);

        return StatusCode(StatusCodes.Status201Created, createdHashTag.asDto);
    }
[HttpGet("{hash_tag_id}")]
    public async Task<ActionResult<HashTagDTO>> GetHashTagById([FromRoute] long hash_tag_id)
    {
        HashTagDTO HashTagDTO = new HashTagDTO();
        var hashtag = await _hashtag.GetHashTagById(hash_tag_id);

        if (hashtag is null)
            return NotFound("No HashTag found with given HashTag Id");

        HashTagDTO = hashtag.asDto;
        HashTagDTO.Posts = (await  _post.GetHashTagPostById(hash_tag_id)).Select(x =>x.asDto).ToList();
        
        return Ok(HashTagDTO);
    }

    [HttpDelete("{hash_tag_id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] long hash_tag_id)
    {
        var existing = await _hashtag.GetHashTagById(hash_tag_id);
        if (existing is null)
            return NotFound("No HashTags found with given HashTag Id");

        var didDelete = await _hashtag.DeleteHashTag(hash_tag_id);

        return NoContent();
    }



}
