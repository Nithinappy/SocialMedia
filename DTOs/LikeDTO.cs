using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record LikeDTO
{

    [JsonPropertyName("user_id")]

    public long UserId { get; set; }
    [JsonPropertyName("post_id")]

    public long PostId { get; set; }

}


public record LikeCreateDTO
{
    [JsonPropertyName("user_id")]
    [Required]
    public long UserId { get; set; }
    [Required]
    [JsonPropertyName("post_id")]

    public long PostId { get; set; }



}

