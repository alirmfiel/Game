namespace GameInventory;

public sealed class Inventory
{
    private List<InventorySlot> _slots = new List<InventorySlot>();
    
    public void Add(Item item)
    {
        _slots.Add(new InventorySlot(item));
    }

    public void Equip(Guid itemId)
    {
        var slot = Find(itemId);
        slot?.Equip();
    }

    public void Unequip(Guid itemId)
    {
        var slot = Find(itemId);
        slot?.Unequip();
    }

    public UsageResult Use(Guid itemId)
    {
        var slot = Find(itemId);
        return slot?.Use() ?? new UsageResult(false, "Не найден");
    }

    public UpgradeResult Upgrade(Guid itemId, IUpgradeStrategy strategy)
    {
        var slot = Find(itemId);
        
        if (slot?.Item is IUpgradeable upgradeable)
            return upgradeable.UpgradeWith(strategy, null);
        
        return new UpgradeResult(false, "Нельзя улучшить");
    }

    private InventorySlot? Find(Guid id)
    {
        return _slots.FirstOrDefault(slot => slot.Item.Id == id);
    }

    public string Describe()
    {
        string info = "";
        foreach (var slot in _slots)
        {
            info += slot.Item.Name + " - " + slot.State + "\n";
        }

        return info;
    }
}