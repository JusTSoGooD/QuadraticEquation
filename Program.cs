using System;

namespace QuadraticEquation
{
    class Program
    {
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
            Console.WriteLine("Здравствуйте, как к вам обращаться?");
            string name = Console.ReadLine();

            //возможность решить еще уравнения
            while (true)
            {
                Equal(name);
                bool isNewEquationSolutionNeeded = GetUserChoice($"{name}, хотите решить еще одно уравнение?");
                if (!isNewEquationSolutionNeeded)
                {
                    break;
                }

                bool isNewNameNeeded = GetUserChoice($"{name}, хотите изменить имя пользователя?");
                if (isNewNameNeeded)
                {
                    Console.WriteLine("Введите имя нового пользователя");
                    name = Console.ReadLine();
                }
            }
            Console.ReadKey();
        }


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

            if (D > 0)
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"{name}, мы рады сообщить вам, что решениями уравнения являются корень x1 = {x1} и корень x2 = {x2}");
            }
            else if (D == 0)
            {
                double x1 = -b / (2 * a);
                Console.WriteLine($"{name}, мы рады сообщить вам, что решением уравнения является корень x = {x1}");
            }
            else
            {
                Console.WriteLine($"{name}, к сожалению уравнение не имеет корней");
            }
        }
    }
}
