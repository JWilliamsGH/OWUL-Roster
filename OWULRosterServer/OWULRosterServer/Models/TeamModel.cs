using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OWULRosterServer.Models
{
    public class TeamModel
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Avatar { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase AvatarImage { get; set; }

        [Range(0, 10, ErrorMessage = "Wins must be between 0 and 10 for the season.")]
        public int Wins { get; set; }

        [Range(0, 10, ErrorMessage = "Losses must be between 0 and 10 for the season.")]
        public int Losses { get; set; }

        [Range(0, 10, ErrorMessage = "Ties must be between 0 and 10 for the season.")]
        public int Ties { get; set; }

        [Range(-30, 30, ErrorMessage = "Score must be between -30 and 30 for the season.")]
        public int Score { get; set; }
    }
}