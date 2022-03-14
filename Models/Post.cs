using SocialMedia.DTOs;

namespace SocialMedia.Models;
//    first_name,last_name,user_name,email,mobile,bio,address,passcode

public record Post
{
    public long PostId { get; set; }
    public string PostType { get; set; }
    public long UserId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }



    public PostDTO asDto => new PostDTO
    {
        PostId = PostId,
        PostType = PostType,
        UserId = UserId,
        CreatedAt = CreatedAt
      
    };
}