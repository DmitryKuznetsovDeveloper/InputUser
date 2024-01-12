using InputUser.Controller;
using InputUser.Interfaces;
using InputUser.Model;
using InputUser.Services;

namespace InputUser;

internal class Program
{
    public static void Main(string[] args)
    {
        IServiceFile serviceFile = new FileService();
        ControllerProgram controllerProgram = new ControllerProgram(serviceFile);
        controllerProgram.Run();
    }
}   