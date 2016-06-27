using MyLinkedIn.DataModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace MyLinkedIn.Web.ViewModels
{
    public class SkillViewModel
    {
        public static Expression<Func<UserSkill, SkillViewModel>> ViewModel
        {
            get
            {
                return x => new SkillViewModel
                {
                    Id = x.Id,
                    Name = x.Skill.Name,
                    EndorcementsCount = x.Endorcements.Count,
                    Endorcers = x.Endorcements.Select(e => e.User.UserName)
                };
            }
        }

        public int Id { get; set; }     //on UserSkill

        public string Name { get; set; }

        public int EndorcementsCount { get; set; }

        public IEnumerable<string> Endorcers { get; set; }
    }
}