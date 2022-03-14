using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record HashTagDTO
{

    [JsonPropertyName("hash_tag_name")]

    public string HashName { get; set; }
    public List<PostDTO> Posts { get; set; }


}


public record HashTagCreateDTO
{

    [JsonPropertyName("hash_tag_name")]
    [Required]
    public string HashName { get; set; }
}

