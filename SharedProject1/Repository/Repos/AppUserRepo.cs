using Devops_Auth_MicroService.Interfaces;
using Devops_Auth_MicroService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Devops_Auth_MicroService.Repos
{
    public class AppUserRepo : GenericRepository<User>, IAppUserRepo
    {
        AuthDbContext _context;
        public AppUserRepo(AuthDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public override async Task<User> Add(User user)
        {
            var _user =  await _context.Users.AddAsync(user);
            Console.WriteLine(_user.Entity.Id);
            await SaveChanges();
            return _user.Entity;
           
        }

        public async Task<User> getUserWithCredentials(string username, string password)
        {
            var _user = await _context.Users.Where(el => el.Name == username && el.Password == password).FirstOrDefaultAsync();
            return _user;
        }
    }
}
