
using ConsoleCalculator;

Console.WriteLine("Программа калькулятор");
Console.WriteLine("Введите выражение для вычисления:");

//Expression corrExp = ReadExpression.GetExpression();
Expression parsedExpression = ReadConsole.GetOperation();
float answer = Calculator.GetResultCalculation(
    parsedExpression.OperandOne,
    parsedExpression.OperandTwo,
    parsedExpression.Operation);

Console.WriteLine($"{parsedExpression} = {answer}");