using POS.API.CLONE.Entities;

namespace POS.API.CLONE.IRepositories
{
    public interface UserIRepositories
    {
        Task<List<User_Entity>> getListUser();
        Task<User_Entity> getUserDetail(long user_id);
        Task<User_Entity> userCreate(User_Entity user);
        Task<User_Entity> userModify(User_Entity user);
        Task<User_Entity> userDelete(long user_id);
    }
}
