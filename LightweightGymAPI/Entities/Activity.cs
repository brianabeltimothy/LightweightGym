using System.ComponentModel.DataAnnotations;

namespace LightweightGymAPI.Entities
{
    public class Activity
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
