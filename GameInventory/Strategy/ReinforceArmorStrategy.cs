namespace GameInventory;

public sealed class ReinforceArmorStrategy : IUpgradeStrategy
{
    public string Name => "Укрепление брони";

    public bool Supports(Item item) => item is Armor;

    public UpgradeResult Apply(Item item, Item? material = null)
    {
        var armor = (Armor)item;
        var extra = 2;

        if (material is Armor materialArmor)
        {
            extra += materialArmor.Defense / 4;
        }

        armor.IncreaseDefense(extra);

        return new UpgradeResult(true, $"Защита +{extra}", 1, material != null);
    }
}