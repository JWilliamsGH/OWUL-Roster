using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OWULRosterServer.Models
{
    public class TeamDetailsPlayerModel
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Skill Rating")]
        [Range(500, 5000, ErrorMessage = "Skill Rating must be between 500 and 5000")]
        public int SkillRating { get; set; }

        [DisplayName("Average Kills")]
        [Range(0, 999.99, ErrorMessage = "Average Kills must be between 0 and 999.99")]
        public decimal AverageKills { get; set; }

        [DisplayName("Average Deaths")]
        [Range(0, 999.99, ErrorMessage = "Average Deaths must be between 0 and 999.99")]
        public decimal AverageDeaths { get; set; }

        [DisplayName("Average Assists")]
        [Range(0, 999.99, ErrorMessage = "Average Assists must be between 0 and 999.99")]
        public decimal AverageAssists { get; set; }
    }
}