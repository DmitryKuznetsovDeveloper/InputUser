using InputUser.Model;

namespace InputUser.Interfaces;

public interface IServiceFile
{
    public void CreateDirectory(string path);
    public Task CreateSurnameUsersFile(string path, UserModel userModel);
}