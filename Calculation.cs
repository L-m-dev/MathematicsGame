public enum Operation{
    Plus, Minus, Multiply, Divide
}
public class Helper{
    public static string GetOperationSymbol(Operation operation){
        
        switch(operation){
            case Operation.Plus:
            return "+";
            case Operation.Minus:  
            return "-";
            case Operation.Divide:
            return "/";
            case Operation.Multiply:   
            return "*";
    }
    throw new Exception("Invalid Operation");
 }

    public static int GetIntegerFromWriteLine(){
        int number = 0; 
        
        Int32.TryParse(Console.ReadLine().Trim(), out number);
        
        return number;
    }
    
}
public class Calculation{
    public int FirstOperand {get;set;} 
    public int SecondOperand {get;set;}
    public Operation Operation    {get;set;}
    public int Result {get;set;}

    public Calculation(int firstOperand, int secondOperand, Operation operation, int result){
        this.FirstOperand = firstOperand;
        this.SecondOperand = secondOperand;
        this.Operation = operation;
        this.Result = result;
    }

    public override string ToString()
    {
        return $"{FirstOperand} {Operation} {SecondOperand} = {Result}";
    }
}