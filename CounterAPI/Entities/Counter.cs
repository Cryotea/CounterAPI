using System;
using System.Collections.Generic;

namespace CounterAPI.Entities;

public partial class Counter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Count { get; set; } = 0;

    public Counter(string name)
    {
        Name = name;
    }
    public int IncreaseCount(int amount)
    {
        Count += amount;
        return Count;
    }

    public int DecreaseCount(int amount)
    {
        Count -= amount;
        return Count;
    }
}