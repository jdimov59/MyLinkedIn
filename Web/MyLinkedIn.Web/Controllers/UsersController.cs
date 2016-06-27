using MyLinkedIn.Data;
using MyLinkedIn.DataModels;
using MyLinkedIn.Web.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MyLinkedIn.Web.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(IMyLinkedInDataUoW data) : base(data)
        {
        }
        // GET: Users
        public ActionResult Index(string username)
        {
            // 1
            //var user = this.Data.Users
            //    .All()
            //    .FirstOrDefault(x => x.UserName == username);

            //  3.a
            //var user = this.Data.Users
            //    .All()
            //    .Where(x => x.UserName == username)
            //    .Select(x => new UserViewModel
            //    {
            //        UserName = x.UserName,
            //        Email = x.Email,
            //        FullName = x.FullName,
            //        AvatarUrl = x.AvatarUrl,
            //        ContactInfo = x.ContactInfo,
            //        Summary = x.Summary
            //    })
            //    .FirstOrDefault();

            //  3.b
            var user = this.Data.Users
                .All()
                .Include(x => x.Certifications)
                .Include(x => x.Skills)
                .Include("Skills.Skill")
                .Include("Skills.Skill.User")
                .Where(x => x.UserName == username)
                .Select(UserViewModel.ViewModel)
                .FirstOrDefault();

            if (user == null)
            {
                return this.HttpNotFound("User does not exist!");
            }

            //   1
            //var userViewModel = new UserViewModel()
            //{
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    FullName = user.FullName,
            //    AvatarUrl = user.AvatarUrl,
            //    ContactInfo = user.ContactInfo,
            //    Summary = user.Summary
            //};

            //  2
            //var userViewModel = UserViewModel.FromModel(user);

            //  2
            //return View(userViewModel);

            //  3
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndorceUserForSkill(int id)
        {
            //return Content("Marhaba");
            // TODO: Optimize queries!
            var hasExistingEndorcement =
                this.Data.Endorcements.All().Any(x => x.UserId == this.UserProfile.Id && x.UserSkillId == id);
            if (!hasExistingEndorcement)
            {
                this.Data.Endorcements.Add(new Endorcement
                {
                    UserId = this.UserProfile.Id,
                    UserSkillId = id
                });
                this.Data.SaveChanges();
            }

            var endorcements =
                this.Data.Endorcements.All().Where(x => x.UserSkillId == id);
            var endorcementsCount = endorcements.Count();
            var endorcers = endorcements.Select(x => x.User.UserName).ToList();


            return this.Content(string.Format("{0} ({1})", endorcementsCount, string.Join(",", endorcers)));
        }
    }
}