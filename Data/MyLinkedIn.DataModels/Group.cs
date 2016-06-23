using System.Collections.Generic;

namespace MyLinkedIn.DataModels
{
    public class Group
    {
        private ICollection<User> members;
        private ICollection<Discussion> discussions;

        public Group()
        {
            members = new HashSet<User>();
            discussions = new HashSet<Discussion>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public GroupeType Type { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public string Website { get; set; }

        public virtual ICollection<User> Members
        {
            get { return members; }
            set { members = value; }
        }

        public virtual ICollection<Discussion> Discussions
        {
            get { return discussions; }
            set { discussions = value; }
        }
    }
}