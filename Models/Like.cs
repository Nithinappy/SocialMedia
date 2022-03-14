using SocialMedia.DTOs;

namespace SocialMedia.Models;
//    first_name,last_name,user_name,email,mobile,bio,address,passcode

public record Like
{
    public long LikeId { get; set; }
    public long PostId { get; set; }
    public long UserId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }



    public LikeDTO asDto => new LikeDTO
    {
        PostId = PostId,
        UserId = UserId,
      
    };
}