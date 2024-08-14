using System.Collections;
using System.Net.Http.Json;
using System.Numerics;
using System.Text.Json.Serialization;

Random randomGenerator = new Random();
ArrayList calculationResultHistory = new ArrayList();


while (true)
{
    int selection = 0;
    bool validSelection = false;

    Console.WriteLine("---Math Game---");
    Console.WriteLine("Select the operation:");
    Console.WriteLine("1 - Plus");
    Console.WriteLine("2 - Minus");
    Console.WriteLine("3 - Multiply");
    Console.WriteLine("4 - Divide");
    Console.WriteLine("0 - Exit");


    while (!validSelection)
    {
        int.TryParse(Console.ReadLine(), out selection);
        if (selection >= 0 && selection <= 4)
        {
            validSelection = true;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid choice. Should use one of the provided options.");
        }

    }

    if (selection == 0)
    {
        break;
    }

    Console.WriteLine("You can type 0 to go back to the Main Menu.");

    if (selection == 1)
    {
        //plus
        while (true)
        {
            Calculation calculation = CreateCalculation(Operation.Plus);
            Console.WriteLine($"{calculation.FirstOperand} {Helper.GetOperationSymbol(calculation.Operation)} {calculation.SecondOperand} equals?");
            int userResult = Helper.GetIntegerFromWriteLine();
            if (userResult == 0)
            {
                break;
            }
            if (userResult == calculation.Result)
            {
                calculationResultHistory.Add(calculation);
                Console.WriteLine($"CONGRATULATIONS!!! the result was {calculation.Result}");
            }
            else
            {
                Console.WriteLine($"Incorrect, the result was {calculation.Result} ");
            }
            Console.WriteLine("----------------------------");
        }

    }
    else if (selection == 2)
    {
        //subtraction
        while (true)
        {
            Calculation calculation = CreateCalculation(Operation.Minus);
            Console.WriteLine($"{calculation.FirstOperand} {Helper.GetOperationSymbol(calculation.Operation)} {calculation.SecondOperand} equals?");
            int userResult = Helper.GetIntegerFromWriteLine();
            if (userResult == 0)
            {
                break;
            }
            if (userResult == calculation.Result)
            {
                calculationResultHistory.Add(calculation);
                Console.WriteLine($"CONGRATULATIONS!!! the result was {calculation.Result}");
            }
            else
            {
                Console.WriteLine($"Incorrect, the result was {calculation.Result} ");
            }
            Console.WriteLine("----------------------------");
        }

    }
    else if (selection == 3)
    {
        //multiply
        while (true)
        {
            Calculation calculation = CreateCalculation(Operation.Multiply);
            Console.WriteLine($"{calculation.FirstOperand} {Helper.GetOperationSymbol(calculation.Operation)} {calculation.SecondOperand} equals?");
            int userResult = Helper.GetIntegerFromWriteLine();
            if (userResult == 0)
            {
                break;
            }
            if (userResult == calculation.Result)
            {
                calculationResultHistory.Add(calculation);
                Console.WriteLine($"CONGRATULATIONS!!! the result was {calculation.Result}");
            }
            else
            {
                Console.WriteLine($"Incorrect, the result was {calculation.Result} ");
            }
            Console.WriteLine("----------------------------");
        }
    }
    else if (selection == 4)
    {
        //divide
        while (true)
        {
            Calculation calculation = CreateCalculation(Operation.Divide);
            Console.WriteLine($"{calculation.FirstOperand} {Helper.GetOperationSymbol(calculation.Operation)} {calculation.SecondOperand} equals?");
            int userResult = Helper.GetIntegerFromWriteLine();
            if (userResult == 0)
            {
                break;
            }
            if (userResult == calculation.Result)
            {
                calculationResultHistory.Add(calculation);
                Console.WriteLine($"CONGRATULATIONS!!! the result was {calculation.Result}");
            }
            else
            {
                Console.WriteLine($"Incorrect, the result was {calculation.Result} ");
            }
            Console.WriteLine("----------------------------");
        }



    }

}

Calculation res = CreateCalculation(Operation.Divide);

Console.WriteLine(res.ToString());


Calculation CreateCalculation(Operation operation, int difficulty = 1)
{
    int maximumNumber = 0;

    if (difficulty == 1)
    {
        maximumNumber = 20;
    }
    else if (difficulty == 2)
    {
        maximumNumber = 100;
    }
    else if (difficulty == 3)
    {
        maximumNumber = 500;
    }

    Calculation calculation;
    switch (operation)
    {
        case Operation.Plus:
            calculation = Sum(maximumNumber);
            return calculation;
        case Operation.Minus:
            calculation = Minus(maximumNumber);
            return calculation;
        case Operation.Multiply:
            calculation = Multiply(maximumNumber);
            return calculation;
        case Operation.Divide:
            try
            {
                calculation = Divide(maximumNumber);
                return calculation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;

        default:
            break;
    }

    throw new InvalidOperationException("Invalid operation. Can only be + - * /");

}


Calculation Sum(int maximumNumber)
{

    //sum is commutative
    int firstOperand = randomGenerator.Next(1, maximumNumber);
    int secondOperand = randomGenerator.Next(1, maximumNumber);
    int result = firstOperand + secondOperand;

    Operation operation = Operation.Plus;

    Calculation calculation = new Calculation(firstOperand, secondOperand, operation, result);

    return calculation;
}

Calculation Minus(int maximumNumber)
{

    int firstOperand = randomGenerator.Next(1, maximumNumber);
    int secondOperand = randomGenerator.Next(1, firstOperand);
    int result = firstOperand - secondOperand;

    Operation operation = Operation.Minus;

    Calculation calculation = new Calculation(firstOperand, secondOperand, operation, result);

    return calculation;
}

Calculation Multiply(int maximumNumber)
{

    int firstOperand = randomGenerator.Next(1, maximumNumber);
    int secondOperand = randomGenerator.Next(2, maximumNumber);
    int result = firstOperand * secondOperand;

    Operation operation = Operation.Multiply;

    Calculation calculation = new Calculation(firstOperand, secondOperand, operation, result);

    return calculation;

}

Calculation? Divide(int maximumNumber)
{

    bool validDivision = false;

    Operation operation = Operation.Divide;

    while (!validDivision)
    {
        int firstOperand = randomGenerator.Next(1, maximumNumber);
        int secondOperand = randomGenerator.Next(2, firstOperand);
        int result = firstOperand / secondOperand;

        if (result * secondOperand == firstOperand)
        {
            Calculation calculation = new Calculation(firstOperand, secondOperand, operation, result);
            return calculation;

        }

    }
    return null;
}


