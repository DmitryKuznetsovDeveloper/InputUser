using System.Globalization;
using InputUser.Interfaces;

namespace InputUser.Model;

public sealed class UserModel
{
    public string Surname { get; private set; }
    public string Name { get; private set; }
    public string Patronymic { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public int PhoneNumber { get; private set; }
    public string Gender { get; private set; }

    /// <summary>
    /// Конструктор класса который заполняет поля через парсинг строки
    /// </summary>
    /// <param name="text"></param>
    public UserModel(string text) => ParseTextInUser(text);

    /// <summary>
    /// Распарсить информацию в пользователя
    /// </summary>
    /// <param name="text"></param>
    private void ParseTextInUser(string text)
    {
        string[] temp = text.Split(" ");
        if (temp.Length < 5)
            throw new Exception("incorrect information provided");

        Surname = temp[0];
        Name = temp[1];
        Patronymic = temp[2];
        DateOfBirth = Convert.ToDateTime(temp[3]);
        if (int.TryParse(temp[4], out int phone))
            PhoneNumber = phone;
        else
            throw new Exception("incorrect phone number");
        Gender = temp[5];
    }

    /// <summary>
    /// Переопределяем метод для записи в файл 
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
        $"<{Surname}><{Name}><{Patronymic}><{DateOfBirth.ToString("dd.MM.yyyy")}><{PhoneNumber}><{Gender}>";
}