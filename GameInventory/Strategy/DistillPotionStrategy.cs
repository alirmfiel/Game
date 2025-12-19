namespace GameInventory;

public sealed class DistillPotionStrategy : IUpgradeStrategy
{
    public string Name => "Дистилляция зелья";

    public bool Supports(Item item) => item is Potion;

    public UpgradeResult Apply(Item item, Item? material = null)
    {
        var potion = (Potion)item;
        var extra = 5; 

        if (material is Potion otherPotion)
        {
            extra += otherPotion.HealAmount / 2;
        }

        potion.IncreasePotency(extra);

        return new UpgradeResult(true, $"Лечение +{extra}", 1, material != null);
    }
}