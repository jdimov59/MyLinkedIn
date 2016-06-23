using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyLinkedIn.Data.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MyLinkedIn.DataModels
{
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Certification> certifications;
        private ICollection<Project> projects;
        private ICollection<Experience> experiences;
        private ICollection<UserLanguage> userLanguages;
        private ICollection<Group> groups;
        private ICollection<UserSkill> skills;

        public User()
        {
            CreatedOn = DateTime.Now;
            ContactInfo = new ContactInfo();
            certifications = new HashSet<Certification>();
            projects = new HashSet<Project>();
            experiences = new HashSet<Experience>();
            userLanguages = new HashSet<UserLanguage>();
            groups = new HashSet<Group>();
            skills = new HashSet<UserSkill>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public virtual ICollection<Certification> Certifications
        {
            get{ return certifications; }
            set{ certifications = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public virtual ICollection<Experience> Experiences
        {
            get { return experiences; }
            set { experiences = value; }
        }

        public virtual ICollection<UserLanguage> Languages
        {
            get { return userLanguages; }
            set { userLanguages = value; }
        }

        public virtual ICollection<Group> Groups
        {
            get { return groups; }
            set { groups = value; }
        }

        public virtual ICollection<UserSkill> Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
