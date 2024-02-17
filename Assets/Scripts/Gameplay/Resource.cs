public class Resource
{
    public string name;
    public int quantity;

    public Resource(string name, int quantity)
    {
        this.name = name;
        this.quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
        quantity += amount;
    }

    public void RemoveQuantity(int amount)
    {
        quantity -= amount;
        if (quantity < 0)
        {
            quantity = 0;
        }
    }

    // Метод для проверки, достаточно ли ресурсов для выполнения определенного действия
    public bool HasEnough(int amount)
    {
        return quantity >= amount;
    }
}
