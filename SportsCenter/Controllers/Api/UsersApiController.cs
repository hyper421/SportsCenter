using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsCenter.Areas.Admin.Models;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models.Hashing;
using SportsCenter.Services;
using Test.Models.DavidModel;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Users/{action}")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        HashingPassword hashingPassword = new HashingPassword();
        private readonly SportsCenterDbContext context;
        private readonly UploadService uploadService;


        public UsersApiController(SportsCenterDbContext dbContext, UploadService uploadService)
        {
            this.context = dbContext;
            this.uploadService = uploadService;
        }
        [HttpPost]
        public async Task<bool> Create(CreateUserModel model)
        {
            try
            {
                var result = await uploadService.Upload(model.Image, "Users");
                Random random = new Random();//亂數
                var Salt = random.Next(0, 100).ToString();
                model.Password = hashingPassword.HashPassword($"{model.Password}{Salt}");
                if (result.Item1)
                {
                    context.Member.Add(new DataAccess.Entity.Member
                    {
                        Role=model.Role,
                        IsActive = model.IsActive ? 1 : 0,
                        Name = model.Name,
                        ImagePath = result.Item2,
                        Account = model.Account,
                        Salt = Salt,
                        Password = model.Password,
                        Address = model.Address,
                        Email = model.Email,
                        Phone = model.Phone
                    });
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<bool> Update(CategoryUpdateDto model)
        {
            try
            {
                var needUpdate = model.Image != null;
                var path = "";
                var data = context.Member.FirstOrDefault(x => x.Id == model.Id);
                if (data == null) return false;

                if (model.Image != null)
                {
                    var result = await uploadService.Upload(model.Image, "Users");
                    if (!result.Item1) return false;
                    path = result.Item2;
                }
                data.IsActive = model.IsActive ? 1 : 0;
                data.Name = model.Name;

                if (needUpdate) data.ImagePath = path;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public object GetAll()
        {
            return context.Member.Select(x => new
            {
                x.Name,
                IsActive = x.IsActive == 1,
                x.Id,
                x.Account,
                x.Phone,
                path = x.ImagePath
            }).ToList();
        }
        [Route("{id}")]
        public object GetData(int id)
        {
            var data = context.Member.First(x => x.Id == id);
            return new
            {
                data.Name,
                IsActive = data.IsActive == 1,
                data.Id,
                path = data.ImagePath
            };
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                context.Member.Remove(new DataAccess.Entity.Member() { Id = id });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
