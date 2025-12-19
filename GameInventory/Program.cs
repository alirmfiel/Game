using System;
using GameInventory;

public class Program
{
    public static void Main()
    {
        var inventory = new Inventory();
        var factory = new SimpleItemFactory();

        var swordBuilder = new WeaponBuilder();
        swordBuilder.Named("Стальной меч");
        swordBuilder.SetDescription("Обычный меч");
        swordBuilder.WithDamage(12);
        swordBuilder.SetSpeed(1.0);
        var sword = swordBuilder.Build();
        inventory.Add(sword);
        var swordId = sword.Id;

        var armorBuilder = new ArmorBuilder();
        armorBuilder.Named("Кольчуга");
        armorBuilder.SetDescription("Легкая защита");
        armorBuilder.WithDefense(8);
        var armor = armorBuilder.Build();
        inventory.Add(armor);
        var armorId = armor.Id;

        var potionBuilder = new PotionBuilder();
        potionBuilder.Named("Зелье здоровья");
        potionBuilder.Healing(25);
        var potion = potionBuilder.Build();
        inventory.Add(potion);
        var potionId = potion.Id;

        var questBuilder = new QuestItemBuilder();
        questBuilder.Named("Древний ключ");
        questBuilder.ForQuest("Открыть дверь");
        var questItem = questBuilder.Build();
        inventory.Add(questItem);
        var questId = questItem.Id;

        var epicSword = factory.CreateWeapon("Пламенный клинок", true);
        inventory.Add(epicSword);

        inventory.Equip(swordId);
        inventory.Equip(armorId);

        var healResult = inventory.Use(potionId);

        inventory.Use(questId);

        var upgradeResult = inventory.Upgrade(swordId, new SharpenWeaponStrategy(5));

        Console.WriteLine("\nИнвентарь:");
        Console.WriteLine(inventory.Describe());
    }
}