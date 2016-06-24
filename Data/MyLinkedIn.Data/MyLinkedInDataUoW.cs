using MyLinkedIn.Data.Common.Repository;
using MyLinkedIn.DataModels;
using System;
using System.Collections.Generic;

namespace MyLinkedIn.Data
{
    public class MyLinkedInDataUoW
    {
        private IMyLinkedInDbContext context;
        private IDictionary<Type, object> repositories;

        public MyLinkedInDataUoW(IMyLinkedInDbContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return GetRepository<User>(); }
        }

        public IRepository<Certification> Certifications
        {
            get { return GetRepository<Certification>(); }
        }
        
        public IRepository<Discussion> Discussions
        {
            get { return GetRepository<Discussion>(); }
        }

        public IRepository<Experience> Experiences
        {
            get { return GetRepository<Experience>(); }
        }

        public IRepository<Group> Groups
        {
            get { return GetRepository<Group>(); }
        }

        public IRepository<Project> Projects
        {
            get { return GetRepository<Project>(); }
        }

        public IRepository<Skill> Skills
        {
            get { return GetRepository<Skill>(); }
        }

        public IRepository<Endorcement> Endorcements
        {
            get { return GetRepository<Endorcement>(); }
        }

        public IRepository<AdministrationLog> AdministrationLogs
        {
            get { return GetRepository<AdministrationLog>(); }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, context);
                repositories.Add(type, repository);
            }

            return (IRepository<T>)repositories[type];
        }
    }
}
