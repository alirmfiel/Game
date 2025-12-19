namespace GameInventory;

public sealed class InventorySlot
{
    public Item Item { get; }
    public string State { get; private set; } = "Забрали";

    public InventorySlot(Item item)
    {
        Item = item;
    }

    public UsageResult Use()
    {
        if (State == "Использован")
            return new UsageResult(false, "Уже использовано");
            
        if (Item is IUsable usable)
        {
            var result = usable.Use();
            
            if (Item is IConsumable)
                State = "Использован";
                
            return result;
        }
        
        return new UsageResult(false, "Нельзя использовать");
    }

    public void Equip()
    {
        if (State != "Использовано" && Item is IEquipable)
            State = "Надето";
    }

    public void Unequip()
    {
        if (State == "Надето")
            State = "Забрали";
    }
}