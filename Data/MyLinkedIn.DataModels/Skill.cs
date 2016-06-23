using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedIn.DataModels
{
    public class Skill
    {
        private ICollection<UserSkill> users;

        public Skill()
        {
            users = new HashSet<UserSkill>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserSkill> UserSkills
        {
            get { return users; }
            set { users = value; }
        }
    }
}
