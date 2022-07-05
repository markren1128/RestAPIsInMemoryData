using System.ComponentModel.DataAnnotations;

//[Required(ErrorMessage = "You should provide a name value")] // Data Annotations

namespace RestAPIsInMemoryData.Models
{
    public class ChartGroupForUpdateDto
    {
        [MaxLength(200)]
        public string Description { get; set; }
    }
}