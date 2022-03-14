using SocialMedia.DTOs;

namespace SocialMedia.Models;
//    first_name,last_name,user_name,email,mobile,bio,address,passcode

public record HashTag
{
    public long HashTagId { get; set; }
    public string HashName { get; set; }



    public HashTagDTO asDto => new HashTagDTO
    {
        HashName = HashName,

    };
}