namespace GameInventory;

public sealed class Armor : Item, IEquipable, IUpgradeable
{
    public Armor(
        string name,
        string description,
        Rarity rarity,
        int defense,
        decimal weight,
        string slot = "Body")
        : base(name, description, rarity, ItemCategory.Armor, weight)
    {
        Defense = defense;
        Slot = slot;
    }

    public int Defense { get; private set; }

    public string Slot { get; }

    public int UpgradeLevel { get; private set; }

    public override string Details()
    {
        return $"{Name} - защита {Defense} ({Rarity})";
    }

    public UpgradeResult UpgradeWith(IUpgradeStrategy strategy, Item? material = null)
    {
        var result = strategy.Apply(this, material);

        if (result.Success)
        {
            UpgradeLevel += result.LevelIncrease;
        }

        return result;
    }

    internal void IncreaseDefense(int amount)
    {
        Defense += amount;
    }
}