using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage ="Code must contain a minmun of three characters")]
        [MaxLength(14, ErrorMessage = "Code must contain a maximumn of three characters")]
        public string Code { get; set; }
        [Required]
        [MinLength(7, ErrorMessage = "Code must contain a minimun of three characters")]
        [MaxLength(14, ErrorMessage = "Code must contain a maximumn of three characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
