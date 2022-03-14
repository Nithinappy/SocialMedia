using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SocialMedia.Models;

namespace SocialMedia.DTOs;

public record PostDTO
{
    [JsonPropertyName("post_id")]
    public long PostId { get; set; }
    [JsonPropertyName("post_type")]
    public string PostType { get; set; }

    [JsonPropertyName("user_id")]

    public long UserId { get; set; }

    [JsonPropertyName("created_at")]

    public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("posts_CreatedBy")]

    public List<UserDTO> PostCreatedBy { get; set; }
    [JsonPropertyName("my_post_likes")]

    public List<LikeDTO> PostLikes { get; set; }
    [JsonPropertyName("my_post_hash_tags")]

    public List<HashTagDTO> HashTags { get; set; }


}


public record PostCreateDTO
{
    [Required]
    [MinLength(3)]
    [MaxLength(10)]
    [JsonPropertyName("post_type")]
    public string PostType { get; set; }
    [Required]

    [JsonPropertyName("user_id")]

    public long UserId { get; set; }
}
