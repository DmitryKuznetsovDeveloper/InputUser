using System.Text;
using InputUser.Interfaces;
using InputUser.Model;

namespace InputUser.Services;

public sealed class FileService : IServiceFile
{
    /// <summary>
    /// Создаем директорию для файлов если ее нет
    /// </summary>
    /// <param name="path">путь к директории</param>
    public void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    /// <summary>
    /// Создаем файл если его нет и записываем в него информацию
    /// </summary>
    /// <param name="surnameFile">Фамилия названия файла</param>
    /// <param name="text">то что нужно записать</param>
    public async Task CreateSurnameUsersFile(string pathDirectory, UserModel userModel)
    {
        string pathFile = $"{pathDirectory}\\{userModel.Surname}.txt";
        using (StreamWriter writer = new StreamWriter(pathFile, true))
        {
            await writer.WriteLineAsync(userModel.ToString());
        }
    }
}