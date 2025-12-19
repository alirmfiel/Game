namespace GameInventory;

public sealed class PotionBuilder
{
    private string _name = "Зелье";
    private string _description = "Восстанавливает здоровье";
    private Rarity _rarity = Rarity.Common;
    private int _healAmount = 15;
    private decimal _weight = 0.3m;

    public PotionBuilder() { }

    public PotionBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public PotionBuilder Healing(int amount)
    {
        _healAmount = amount;
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

    public Potion Build()
    {
        return new Potion(_name, _description, _rarity, _healAmount, _weight);
    }
}