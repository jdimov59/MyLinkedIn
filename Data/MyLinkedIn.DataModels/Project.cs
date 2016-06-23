using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLinkedIn.DataModels
{
    public class Project
    {
        private ICollection<User> teamMembers;

        public Project()
        {
            teamMembers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Url { get; set; }

        public int OccupationExperienceId { get; set; }

        public virtual Experience OccupationExperience { get; set; }

        public virtual ICollection<User> TeamMembers
        {
            get { return teamMembers; }
            set { teamMembers = value; }
        }
    }
}