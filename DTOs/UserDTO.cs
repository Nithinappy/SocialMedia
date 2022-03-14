using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SocialMedia.Models;

namespace SocialMedia.DTOs;

public record UserDTO
{
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    [JsonPropertyName("user_name")]
    public string UserName { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
    [JsonPropertyName("bio")]
    public string Bio { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("my_posts")]
    public List<PostDTO> MyPosts { get; set; }
    [JsonPropertyName("my_likes")]

    public List<LikeDTO> MyLikes { get; set; }



}


public record UserCreateDTO
{
    [JsonPropertyName("first_name")]
    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string FirstName { get; set; }
    [JsonPropertyName("last_name")]
    [Required]
    [MinLength(3)]
    [MaxLength(255)]

    public string LastName { get; set; }
    [JsonPropertyName("user_name")]
    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string UserName { get; set; }
    [JsonPropertyName("email")]
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }
    [JsonPropertyName("mobile")]
    [Required]
    public long Mobile { get; set; }
    [JsonPropertyName("bio")]
    [Required]
    [MaxLength(255)]
    public string Bio { get; set; }
    [JsonPropertyName("address")]
    [Required]
    [MaxLength(255)]
    public string Address { get; set; }
    [JsonPropertyName("passcode")]
    [Required]
    [MinLength(3)]
    [MaxLength(15)]
    public string Passcode { get; set; }



}
public record UserUpdateDTO
{

    public string UserName { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string Address { get; set; }

}