namespace GameInventory;

public class SimpleItemFactory
{
    public Weapon CreateWeapon(string name, bool epic = false)
    {
        if (epic)
            return new Weapon(name, "Супер оружие", Rarity.Epic, 18, 1.2, 1.4m);
        else
            return new Weapon(name, "Обычное оружие", Rarity.Common, 10, 1.0, 1.6m);
    }

    public Armor CreateArmor(string name, bool epic = false)
    {
        if (epic)
            return new Armor(name, "Супер броня", Rarity.Epic, 12, 3.5m);
        else
            return new Armor(name, "Обычная броня", Rarity.Common, 6, 4.0m);
    }

    public Potion CreatePotion(string name, bool epic = false)
    {
        if (epic)
            return new Potion(name, "Супер зелье", Rarity.Epic, 50, 0.3m);
        else
            return new Potion(name, "Простое зелье", Rarity.Common, 25, 0.5m);
    }
}

