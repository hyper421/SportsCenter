using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using Test.Models.DavidModel;

namespace SportsCenter.Controllers.Api
{
    [ApiController]
    public class UserManagementApiController : ControllerBase
    {
        private readonly SportsCenterDbContext context;

        public UserManagementApiController(SportsCenterDbContext dbContext)
        {
            this.context = dbContext;
        }
        [Route("api/ShowUsers")]
        public IEnumerable<Member> ShowUsers()
        {
            return context.Member;
        }
        [Route("api/ChangeUser")]
        [HttpPost]
        public bool ChangeUser([FromBody] ChangeUserModel model)
        {
            var user = (from a in context.Member
                        where a.Id == model.Id
                        select a).FirstOrDefault();
            if (user == null)
            {
                return false;
            }

            else
            {
                user.IsActive = model.IsActive;
                user.Account = model.Account;
                user.Name = model.Name;
                user.Phone = model.Phone;
                user.Email = model.Email;
                user.Address = model.Address;
                user.Role = model.Role;
                context.Update(user);
            }
            context.SaveChanges();
            return true;
        }
        [Route("api/DeleteUser")]
        [HttpPost]
        public bool DeleteUser([FromBody] DeleteUserModel model)
        {
            if (model.Id == null || context.Member == null)
            {
                return false;
            }

            var user = (from a in context.Member
                        where a.Id == model.Id
                        select a).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            context.Member.Remove(user);
            context.SaveChanges();
            return true;
        }
    }
}
