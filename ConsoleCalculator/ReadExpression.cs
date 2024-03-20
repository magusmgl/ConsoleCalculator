using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public static class ReadExpression
    {
        public static Expression GetExpression()
        {
            char[] operations = { '+', '-', '/', '*' };
            string operation = string.Empty;
            int number1 = 0;
            int number2 = 0;

            bool isCorrectExp = false;

            do
            {
                string stringExpression = Console.ReadLine();

                if (String.IsNullOrEmpty(stringExpression))
                {
                    Console.WriteLine("Пустое выражение. Повторите ввод:");
                    continue;
                }

                int indexOfOperand = stringExpression.IndexOfAny(operations);

                if (indexOfOperand == -1)
                {
                    Console.WriteLine("Некорректное выражение. Повторите ввод:");
                    continue;
                }

                operation = stringExpression.Substring(indexOfOperand, 1);
                var stringNumberOne = stringExpression.Substring(0, indexOfOperand - 1);
                var stringNumberTwo = stringExpression.Substring(indexOfOperand + 1, stringExpression.Length - indexOfOperand - 1);

                if (Int32.TryParse(stringNumberOne, out number1) == false ||
                    Int32.TryParse(stringNumberTwo, out number2) == false)
                {
                    Console.WriteLine("Некорректные числовые значения. Повторите ввод:");
                    continue;
                }

                if (operation == "/" && number2 == 0)
                {
                    Console.WriteLine("Некорректная операция деления. На 0 делить нельзя.\nПовторите ввод:");
                    continue;
                }

                isCorrectExp = true;

            } while (isCorrectExp == false);

            Expression expressionObject = new Expression(number1, number2, operation);

            return expressionObject;
        }
    }
}

