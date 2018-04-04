using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInformation
{
    class Programm
    {
        static void Main(string[] args)
        {
            Server server = new Server("http://localhost:4000/IContract");
            server.OpenHost();

            Console.WriteLine("Application ready for get message!!!");

            //service.Say();

            Console.ReadKey();
            server.CloseHost();
            Console.ReadKey();
        }
    }
}


//Написать консольное .NET приложение, позволяющее пользователю получить:
//1. Список всех процессов
//2. Выбрать процесс по PID
//3. Запустить процесс
//4. Оставить процесс
//5. Показать информацию о потоках
//6. Показать информацию о модулях
//Предоставить пользователю меню выбора (по пунктам).