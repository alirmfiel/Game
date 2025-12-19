namespace GameInventory;

public sealed class QuestItemBuilder
{
    private string _name = "Квестовый предмет";
    private string _description = "Важно для задания";
    private string _questName = "Задание";
    private Rarity _rarity = Rarity.Common;
    private decimal _weight = 0.1m;

    public QuestItemBuilder() { }

    public QuestItemBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public QuestItemBuilder ForQuest(string questName)
    {
        _questName = questName;
        return this;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetRarity(Rarity rarity)
    {
        _rarity = rarity;
    }

    public void SetWeight(decimal weight)
    {
        _weight = weight;
    }

    public QuestItem Build()
    {
        return new QuestItem(_name, _description, _questName, _rarity, _weight);
    }
}