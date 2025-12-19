namespace GameInventory;

public enum ItemCategory
{
    Weapon,
    Armor,
    Potion,
    Quest
}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

public abstract class Item
{
    protected Item(string name, string description, Rarity rarity, ItemCategory category, decimal weight)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Rarity = rarity;
        Category = category;
        Weight = weight;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public Rarity Rarity { get; }

    public ItemCategory Category { get; }

    public decimal Weight { get; }

    public virtual bool IsConsumable => false;

    public virtual string Details() => $"{Name} ({Category}, {Rarity})";
}

public sealed class UsageResult
{
    public UsageResult(bool success, string message, int value = 0)
    {
        Success = success;
        Message = message;
        Value = value;
    }

    public bool Success { get; }

    public string Message { get; }

    public int Value { get; }
}

public sealed class UpgradeResult
{
    public UpgradeResult(bool success, string message, int levelIncrease = 0, bool materialConsumed = false)
    {
        Success = success;
        Message = message;
        LevelIncrease = levelIncrease;
        MaterialConsumed = materialConsumed;
    }

    public bool Success { get; }

    public string Message { get; }

    public int LevelIncrease { get; }

    public bool MaterialConsumed { get; }
}
