namespace GameInventory;

public sealed class ArmorBuilder
{
    private string _name = "Броня";
    private string _description = "Базовая защита";
    private Rarity _rarity = Rarity.Common;
    private int _defense = 5;
    private decimal _weight = 3.0m;
    private string _slot = "Body"; 

    public ArmorBuilder() { }

    public ArmorBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public ArmorBuilder WithDefense(int defense)
    {
        _defense = defense;
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

    public void SetSlot(string slot)
    {
        _slot = slot;
    }

    public Armor Build()
    {
        return new Armor(_name, _description, _rarity, _defense, _weight, _slot);
    }
}