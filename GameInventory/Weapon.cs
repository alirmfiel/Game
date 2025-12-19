namespace GameInventory;

public sealed class Weapon : Item, IEquipable, IUpgradeable
{
    public Weapon(
        string name,
        string description,
        Rarity rarity,
        int damage,
        double attackSpeed,
        decimal weight,
        string slot = "Hand")
        : base(name, description, rarity, ItemCategory.Weapon, weight)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
        Slot = slot;
    }

    public int Damage { get; private set; }

    public double AttackSpeed { get; }

    public string Slot { get; }

    public int UpgradeLevel { get; private set; }

    public override bool IsConsumable => false;

    public override string Details()
    {
        return $"{Name} - урон {Damage} ({Rarity})";
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

    internal void IncreaseDamage(int amount)
    {
        Damage += amount;
    }
}