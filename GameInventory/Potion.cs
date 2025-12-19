namespace GameInventory;

public sealed class Potion : Item, IConsumable, IUpgradeable
{
    public Potion(
        string name,
        string description,
        Rarity rarity,
        int healAmount,
        decimal weight)
        : base(name, description, rarity, ItemCategory.Potion, weight)
    {
        HealAmount = healAmount;
    }

    public int HealAmount { get; private set; }

    public bool IsSpent { get; private set; }

    public int UpgradeLevel { get; private set; }

    public override bool IsConsumable => true;

    public UsageResult Use()
    {
        if (IsSpent)
            return new UsageResult(false, "Зелье уже использовано");

        IsSpent = true;
        return new UsageResult(true, $"Восстановлено {HealAmount} здоровья", HealAmount);
    }

    public UpgradeResult UpgradeWith(IUpgradeStrategy strategy, Item? material = null)
    {
        var result = strategy.Apply(this, material);

        if (result.Success)
            UpgradeLevel += result.LevelIncrease;

        return result;
    }

    internal void IncreasePotency(int amount)
    {
        HealAmount += amount;
    }
}