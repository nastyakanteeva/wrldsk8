// Класс обобщенного массива, который может хранить элементы любого типа
public class GenericArray<T>
{   // Массив для хранения элементов
    private T[] array;
    // Длина массива
    private int length;

    public GenericArray(int size)  // Конструктор, который принимает размер массива и создает массив этого размера
    {
        array = new T[size];
        length = size;
    }

    // Метод для добавления элемента в массив по заданному индексу
    public void Adding_data(int index, T element)
    {
        if (index >= 0 && index < length)
        {
            array[index] = element;
        }
        else
        {
            Console.WriteLine("Недопустимый индекс.");   // Выводим сообщение об ошибке, если индекс недопустимый
        }
    }

    public void Remove_items(int index)  // Метод для удаления элемента из массива по заданному индексу
    {
        if (index >= 0 && index < length)   // Проверяем, является ли индекс допустимым
        {
            array[index] = default(T);     // Удаляем элемент из массива
        }
        else
        {
            Console.WriteLine("Недопустимый индекс.");     // Выводим сообщение об ошибке, если индекс недопустимый
        }
    }

    public T GetElement(int index)      // Метод для получения элемента из массива по заданному индексу
    {
        if (index >= 0 && index < length)   // Проверяем, является ли индекс допустимым 
        {
            return array[index];     // Возвращаем элемент из массива
        }
        Console.WriteLine("Недопустимый индекс.");    // Выводим сообщение об ошибке, если индекс недопустимый
        return default(T);     // Возвращаем значение по умолчанию для типа T
    }

    public int GetLength()     // Метод для получения длины массива
    {
        return length;
    }
}
class PasswordArray : GenericArray<string>   // Класс, представляющий массив паролей, который наследуется от класса GenericArray<string>
{
    public PasswordArray(int size) : base(size) { }       // Конструктор, который принимает размер массива и создает массив этого размера
}
class LoginArray : GenericArray<string>  // Класс, представляющий массив логинов, который наследуется от класса GenericArray<string>
{
    public LoginArray(int size) : base(size) { }      // Конструктор, который принимает размер массива и создает массив этого размера
}
class User  // Класс, представляющий пользователя
{
    public string Login { get; set; }      // Логин пользователя
    public string Password { get; set; }   // Пароль пользователя

    public User(string login, string password)    // Конструктор, который принимает логин и пароль пользователя
    {
        Login = login;
        Password = password;
    }
}
class Program
{
    static void Main()
    {
        LoginArray logins = new LoginArray(10);        // Создаем массив логинов и массив паролей размером 10
        PasswordArray passwords = new PasswordArray(10);

        RegisterUser(logins, passwords, "user1", "pass1");    // Регистрируем первого пользователя
        RegisterUser(logins, passwords, "user2", "pass2");   // Регистрируем первого пользователя

        void RegisterUser(LoginArray logins, PasswordArray passwords, string login, string password)   // Метод для регистрации пользователя и добавления его в массивы логинов и паролей
        {
            int index = FindEmptyIndex(logins);       // Находим первый пустой индекс в массиве логинов
            if (index != -1)      // Если пустой индекс найден
            {
                logins.Adding_data(index, login);       // Добавляем логин и пароль в массивы
                passwords.Adding_data(index, password);
                Console.WriteLine(login + " зарегистрирован.");        // Добавляем логин и пароль в массивы
            }
            else
            {
                Console.WriteLine("НЕТ МЕСТА.");   // Выводим сообщение о том, что нет места для регистрации
            }
        }
        int FindEmptyIndex(GenericArray<string> array)          // Метод для поиска первого пустого индекса в массиве
        {
            for (int i = 0; i < array.GetLength(); i++)          // Перебираем элементы массива
            {
                if (array.GetElement(i) == null)    // Если элемент равен null, значит он пустой
                {
                    return i; // Возвращаем индекс пустого элемента
                }
            }
            return -1;   // Если пустого элемента не найдено, возвращаем -1
            return -1;
        }
    }
}