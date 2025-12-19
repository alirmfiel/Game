namespace GameInventory;

public sealed class WeaponBuilder
{
    private string _name = "Меч";
    private string _description = "Простое оружие";
    private Rarity _rarity = Rarity.Common;
    private int _damage = 8;
    private double _speed = 1.0;
    private decimal _weight = 1.5m;
    private string _slot = "Hand"; 

    public WeaponBuilder() { }

    public WeaponBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public WeaponBuilder WithDamage(int damage)
    {
        _damage = damage;
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

    public void SetSpeed(double speed)
    {
        _speed = speed;
    }

    public void SetWeight(decimal weight)
    {
        _weight = weight;
    }

    public Weapon Build()
    {
        return new Weapon(_name, _description, _rarity, _damage, _speed, _weight, _slot);
    }
}