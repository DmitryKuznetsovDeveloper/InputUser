using InputUser.Interfaces;
using InputUser.Model;
using InputUser.Services;

namespace InputUser.Controller;

public sealed class ControllerProgram
{
    private readonly string pathDirectory = @"D:\UsersInfo";
    private IServiceFile fileService;

    public ControllerProgram( IServiceFile fileService)
    {
        this.fileService = fileService;
    }

    public void Run()
    {
        bool getNewIteration = true;
        try
        {
            fileService.CreateDirectory(pathDirectory);
            while (getNewIteration)
            {
                Console.WriteLine("Введите фамилию, имя, отчество, дату рождения (в формате dd.mm.yyyy)," +
                                  " номер телефона (число без разделителей) и пол(символ латиницей f или m)," +
                                  " разделенные пробелом");
                string? userInfo = Console.ReadLine();
                fileService.CreateSurnameUsersFile(pathDirectory,new UserModel(userInfo));
                Console.WriteLine("Хотите продолжить вводить пользователей ? \n" +
                                  "Введите Y если да " +
                                  "Введите N если нет");
                string? continueExecution = Console.ReadLine();

                if (continueExecution.ToLower() == "y" || continueExecution.ToLower() == "н")
                    getNewIteration = true;

                else if (continueExecution.ToLower() == "n" || continueExecution.ToLower() == "т")
                    getNewIteration = false;
                else
                {
                    throw new Exception("Input Error");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}\n{e.StackTrace}");
        }
    }
}