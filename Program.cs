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
        static void Equ(string name)
        {

            double a, b, c, x1, x2;
            string aStr, bStr, cStr;
            //проверка корректности ввода a
            Console.WriteLine("Введи значение a, " + name);
            aStr = Console.ReadLine();
            bool isInputCorrect = double.TryParse(aStr, out a);
            while (isInputCorrect == false)
            {
                Console.WriteLine("Значение a должно быть обычным дробным числом (без символов, восклицательных знаков и гнилого банана в кармане) ");
                Console.WriteLine("Введи значение a, " + name);
                aStr = Console.ReadLine();
                isInputCorrect = double.TryParse(aStr, out a);

            }

            a = Convert.ToDouble(aStr);
            //проверка корректности ввода b
            Console.WriteLine("Введи значение b, " + name);
            bStr = Console.ReadLine();
            isInputCorrect = double.TryParse(bStr, out b);
            while (isInputCorrect == false)
            {
                Console.WriteLine("Значение b должно быть обычным дробным числом (без символов, восклицательных знаков и гнилого банана в кармане) ");
                Console.WriteLine("Введи значение b, " + name);
                bStr = Console.ReadLine();
                isInputCorrect = double.TryParse(bStr, out b);
            }
            b = Convert.ToDouble(bStr);
            //проверка корректности ввода c
            Console.WriteLine("Введи значение c, " + name);
            cStr = Console.ReadLine();
            isInputCorrect = double.TryParse(cStr, out c);
            while (isInputCorrect == false)
            {
                Console.WriteLine("Значение c должно быть обычным дробным числом (без печатных символов, восклицательных знаков и гнилого банана в кармане) ");
                Console.WriteLine("Введи значение c, " + name);
                cStr = Console.ReadLine();
                isInputCorrect = double.TryParse(cStr, out c);
            }
            c = Convert.ToDouble(cStr);
            //подсчет дискриминанта
            double D = b * b - 4 * a * c;
            //D>0
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine(name + ", мы рады сообщить вам, что решениями уравнения являются корень x1 = " + x1 + " и корень x2 = " + x2);
            }
            //D==0
            else if (D == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine(name + ", мы рады сообщить вам, что решением уравнения является корень x = " + x1);
            }
            //D<0
            else
            {
                Console.WriteLine(name + ", к сожалению уравнение не имеет корней");
            }
        }
    }
}
