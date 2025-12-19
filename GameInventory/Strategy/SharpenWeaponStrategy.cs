namespace GameInventory;

public sealed class SharpenWeaponStrategy : IUpgradeStrategy
{
    private readonly int _bonusDamage;

    public SharpenWeaponStrategy(int bonusDamage = 3)
    {
        _bonusDamage = bonusDamage;
    }

    public string Name => "Заточка оружия";

    public bool Supports(Item item) => item is Weapon;

    public UpgradeResult Apply(Item item, Item? material = null)
    {
        var weapon = (Weapon)item;
        var extra = _bonusDamage;

        if (material is Weapon materialWeapon)
        {
            extra += materialWeapon.Damage / 4;
        }

        weapon.IncreaseDamage(extra);

        return new UpgradeResult(true, $"Урон +{extra}", 1, material != null);
    }
}