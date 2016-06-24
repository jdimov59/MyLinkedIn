using MyLinkedIn.Data.Common.Repository;
using MyLinkedIn.DataModels;

namespace MyLinkedIn.Data
{
    public interface IMyLinkedInDataUoW
    {
        IRepository<User> Users { get; }

        IRepository<Certification > Certifications { get; }

        IRepository<Discussion> Discussions { get; }

        IRepository<Experience> Experiences { get; }

        IRepository<Group> Groups { get; }

        IRepository<Project> Projects { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Endorcement> Endorcements { get; }

        IRepository<AdministrationLog> AdministrationLogs { get; }

        int SaveChanges();
    }
}
