namespace GameInventory;

public interface IEquipable
{
    string Slot { get; }
}

public interface IUsable
{
    UsageResult Use();
}

public interface IConsumable : IUsable
{
    bool IsSpent { get; }
}

public interface IUpgradeable
{
    int UpgradeLevel { get; }

    UpgradeResult UpgradeWith(IUpgradeStrategy strategy, Item? material = null);
}

public interface IUpgradeStrategy
{
    string Name { get; }

    bool Supports(Item item);

    UpgradeResult Apply(Item item, Item? material = null);
}
