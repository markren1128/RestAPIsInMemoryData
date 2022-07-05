using System.ComponentModel.DataAnnotations;

namespace RestAPIsInMemoryData.Models
{
    public class ChartGroupForCreationDto
    {
        //[Required(ErrorMessage = "You should provide a name value")] // Data Annotations
        [MaxLength(200)]
        public string Description { get; set; }
    }
}