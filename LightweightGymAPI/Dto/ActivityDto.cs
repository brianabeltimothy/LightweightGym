using System.ComponentModel.DataAnnotations;

namespace LightweightGymAPI.Dto
{
    public class ActivityDto
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ActivityName { get; set; }

        [Required]
        public DateTime ActivityDate { get; set; }

        [Required]
        public DateTime FinishedAt { get; set; }

        [Required]
        public int TrainerId { get; set; }


    }
}
