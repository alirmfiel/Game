namespace GameInventory;

public sealed class QuestItem : Item, IUsable
{
    public QuestItem(
        string name,
        string description,
        string questName,
        Rarity rarity,
        decimal weight)
        : base(name, description, rarity, ItemCategory.Quest, weight)
    {
        QuestName = questName;
    }

    public string QuestName { get; }

    public UsageResult Use()
    {
        return new UsageResult(true, $"Осмотрен предмет '{Name}' для квеста '{QuestName}'");
    }
}