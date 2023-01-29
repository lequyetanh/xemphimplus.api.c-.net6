using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;

namespace POS.API.CLONE.Repositories
{
    public class UserRepositories:UserIRepositories
    {
    private readonly ApplicationContext _context;

        public UserRepositories(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<User_Entity>> getListUser()
        {
            List<User_Entity> listUser = new List<User_Entity>();
            listUser = _context.User_Object.ToList();
            return listUser;
        }

        public async Task<User_Entity> getUserDetail(long user_id)
        {
            User_Entity user = _context.User_Object.FirstOrDefault(r => r.id == user_id);
            return user;
        }

        public async Task<User_Entity> userCreate(User_Entity user)
        {
            System.Console.WriteLine(user);
            _context.User_Object.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User_Entity> userModify(User_Entity user)
        {
            var userUpdate = _context.User_Object.FirstOrDefault(r => r.id == user.id);

            userUpdate.name = user.name;

            _context.User_Object.Update(userUpdate);
            _context.SaveChanges();
            return userUpdate;
        }

        public async Task<User_Entity> userDelete(long user_id)
        {
            var user = _context.User_Object.FirstOrDefault(r => r.id == user_id);
            _context.User_Object.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }

}
