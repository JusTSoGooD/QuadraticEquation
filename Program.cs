using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace TwentyOne
{
    class CalcTemp
    {
        public static void GetSolutionInfo(string name, double a, double b, double c, double x1, double x2)
        {
            string writepath = @"D:\Projects\Train\AlexH\TwentyOne\TwentyOne\CalcTempInfo.txt";
            StreamWriter sw = new StreamWriter(writepath, true, System.Text.Encoding.Default);
            sw.WriteLine($"Имя пользователя - {name} ");
            //TODO как сделать так, чтобы в уравнении если b или c равнялось нулю, член просто не отображался ( 0x+0)
            sw.WriteLine($"Решаемое уравнение: {a}x^2 + {b}x + {c} = 0");
            sw.WriteLine($"Дата и время решения уравнения - {DateTime.Now} ");
            if (x1 == 0 && x2 == 0)
            {
                sw.WriteLine("Данное уравнение не имеет корней");
            }
            else if (!(x1 == 0) && x2 == 0)
            {
                sw.WriteLine($"Данне уравнение имеет единственный корень - {x1}");
            }
            else
            {
                sw.WriteLine($"Данное уравнение имеет два корня x1 = {x1} и x2 = {x2}");
            }
            sw.WriteLine();
            sw.Close();
        }
        //RGX шняга для проверки валидности ввода имени пользователя
        public static string GetUserName()
        {

            string pattern = @"^([A-Z][a-z]*([ -][A-Z][a-z]*)*)$";
            Regex rgx = new Regex(pattern);
            while (true)
            {
                Console.WriteLine("Введите имя пользователя");
                string name = Console.ReadLine();
                if (rgx.IsMatch(name))
                {
                    return name;
                }
                else Console.WriteLine("Имя пользователя не может содержать цифры, символы (кроме дефиса) а также должно начинаться с большой буквы");
            }
        }
        //Метод для получения ответа да или нет
        public static bool GetUserChoice(string requestMessage)
        {
            Console.WriteLine(requestMessage);
            string userAnswer = Console.ReadLine();

            while (true)
            {
                if (userAnswer.ToLower() == "да")
                {
                    return true;
                }
                else if (userAnswer.ToLower() == "нет")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine($"Нужно ввести 'да' или 'нет', будьте внимательны");
                }
            }

        }
        public static void Main(string[] args)
        {

            //Ввод имени пользователя

            string name = GetUserName();

            //возможность решить еще уравнения
            while (true)
            {
                Equal(name);
                bool isNewEquationSolutionNeeded = GetUserChoice($"{name}, хотите решить еще одно уравнение?");
                if (!isNewEquationSolutionNeeded)
                {
                    break;
                }
                //Возможность сменить имя пользователя
                bool isNewNameNeeded = GetUserChoice($"{name}, хотите изменить имя пользователя?");
                if (isNewNameNeeded)
                {
                    name = GetUserName();
                }
            }
            Console.ReadKey();
        }

        //Проверка корректности ввода коэффициентов
        static double GetDoubleUserInput(string requestMessage, string errorMessage, bool isCanBeZero = true)
        {
            double correctInput;

            while (true)
            {
                Console.WriteLine(requestMessage);
                string inputString = Console.ReadLine();
                bool isInputCorrect = double.TryParse(inputString, out correctInput);

                if (isInputCorrect && (isCanBeZero || correctInput != 0))
                {
                    return correctInput;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        static void Equal(string name)
        {
            // Create templates
            string requestMessageTemplate = $"{name}, введи значение '{{0}}'";
            string errorMessageTemplate = "Значение '{0}' должно быть обычным дробным числом (без печатных символов, восклицательных знаков и гнилого банана в кармане){1}";

            // Get 'a'
            string aRequestMessage = string.Format(requestMessageTemplate, "a");
            string aErrorMessage = string.Format(errorMessageTemplate, "a", " и не равняться нулю");
            double a = GetDoubleUserInput(aRequestMessage, aErrorMessage, false);

            // Get 'b'
            string bRequestMessage = string.Format(requestMessageTemplate, "b");
            string bErrorMessage = string.Format(errorMessageTemplate, "b", "");
            double b = GetDoubleUserInput(bRequestMessage, bErrorMessage);

            // Get 'c'
            string cRequestMessage = string.Format(requestMessageTemplate, "c");
            string cErrorMessage = string.Format(errorMessageTemplate, "c", "");
            double c = GetDoubleUserInput(cRequestMessage, cErrorMessage);

            //подсчет дискриминанта
            double D = b * b - 4 * a * c;
            double x1 = 0;
            double x2 = 0;
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"{name}, мы рады сообщить вам, что решениями уравнения являются корень x1 = {x1} и корень x2 = {x2}");

            }
            else if (D == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine($"{name}, мы рады сообщить вам, что решением уравнения является корень x = {x1}");
            }
            else
            {
                Console.WriteLine($"{name}, к сожалению уравнение не имеет корней");
            }
            GetSolutionInfo(name, a, b, c, x1, x2);
        }
    }
}
