using SocialMedia.DTOs;

namespace SocialMedia.Models;
//    first_name,last_name,user_name,email,mobile,bio,address,passcode

public record User
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public long Mobile { get; set; }
    public string Bio { get; set; }
    public string Address { get; set; }
    public string Passcode { get; set; }
    public DateTimeOffset CreatedAt { get; set; }



    public UserDTO asDto => new UserDTO
    {
        UserId=UserId,
        FirstName = FirstName,
        LastName = LastName,
        UserName = UserName,
        Bio = Bio,
        Mobile = Mobile,
        Email = Email,
        Address = Address
    };
}