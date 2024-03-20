using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public static class ReadConsole
    {
        private static Regex pattern = new Regex(@"^(-?\d+)\s+?([-+*/])\s+?(-?\d+)$", RegexOptions.Compiled);

        public static Expression GetOperation()
        {
            bool isCorrectData = false;
            string operand = String.Empty;
            float numberOne = 0;
            float numberTwo = 0;

            while (isCorrectData == false)
            {
                string operation = Console.ReadLine();

                if (String.IsNullOrEmpty(operation))
                {
                    Console.WriteLine("Введено пустое выражение.\nВведите операцию еще раз: ");
                    continue;
                }

                var match = pattern.Match(operation);
                if (match.Success)
                {
                    operand = match.Groups[2].Value;

                    if (float.TryParse(match.Groups[1].Value, out numberOne) == false ||
                        float.TryParse(match.Groups[3].Value, out numberTwo) == false)
                    {
                        Console.WriteLine($"Введеное значения не является числом.\nВведите операцию еще раз:");
                    }

                    else if (operand == "/" && numberTwo == 0)
                    {
                        Console.Write($"Некорректная операция деления: на 0 делить нельзя.\nВведите операцию еще раз:\n");
                    }
                    else
                    {
                        isCorrectData = true;
                    }
                }
                else
                {
                    Console.WriteLine("Введена некорректная операция.\nВведите операцию еще раз: ");
                }
            }

            Expression expObj = new(numberOne, numberTwo, operand);
            return expObj;
        }

    }
}

