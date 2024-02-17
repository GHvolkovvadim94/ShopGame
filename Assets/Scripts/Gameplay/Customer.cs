using System;

[Serializable]
public class Customer
{
    public string Name { get; private set; }
    public Order Order { get; private set; }
    public float decisionTime;

    public Customer(Order order, string name)
    {
        Order = order;
        Name = name;
    }

}
