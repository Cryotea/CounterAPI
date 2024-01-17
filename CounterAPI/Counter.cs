namespace CounterAPI;

public class Counter
{
    public Counter(int idinput)
    {
        Id = idinput;
    }
    public int Id { get; set; }
    public int Count { get; set; }

    public Func<int, int, int> adder = ((num1, num2) => num1 + num2);

    public int IncreaseCount(int Amount)
    {
        Count += Amount;
        return Count;
    }

    public int DecreaseCount(int Amount)
    {
        Count -= Amount;
        return Count;
    }


    public int AddTwoNumbers(int number1, int number2)
    {
        adder.Invoke(number1, number2);
        return number1 + number2;
    }
}