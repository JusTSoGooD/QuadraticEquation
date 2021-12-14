using System;

namespace QuadraticEquation
{
    class Program
    {
        public static void Main(string[] args)
        {
            string name, isNewEquationSolutionNeededStr, isNewNameNeededStr;
            //Ввод имени пользователя
            Console.WriteLine("Здравствуйте, как к вам обращаться?");
            name = Console.ReadLine();
            //возможность решить еще уравнения 
            do
            {
                Console.WriteLine("Хотите решить уравнение? (впишите 'да' или 'нет')");
                isNewEquationSolutionNeededStr = Console.ReadLine();
                switch (isNewEquationSolutionNeededStr)
                {
                    case "да":              //TODO Смена пользователя (?Как сделать выбор из вариантов да или нет чтобы исключить ошибки ввода?)
                        Console.WriteLine("Хотите сменить пользователя? (впишите да или нет)");
                        isNewNameNeededStr = Console.ReadLine();
                        if (isNewNameNeededStr == "да")
                        {
                            Console.WriteLine("Введите имя нового пользователя");               // TODO При первом же решении предлагает сменить пользователя, хуета
                            name = Console.ReadLine();
                        }
                        Equ(name);
                        break;
                    case "нет":
                        break;
                    default:
                        Console.WriteLine("Чет ты хуйню написал, попробуй еще раз (может не стоит писать с заглавной буквы)");
                        break;
                }
            } while (!(isNewEquationSolutionNeededStr == "нет"));
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
                    break;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }

            return correctInput;
        }

        static void Equ(string name)
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
