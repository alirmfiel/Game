using GameInventory;
using Xunit;

namespace GameTests;

public class Tests
{
    [Fact]
    public void Builder_CreatesWeaponWithProperties()
    {
        var weapon = new WeaponBuilder()
            .Named("Топор")
            .WithDamage(15)
            .Build();

        Assert.Equal("Топор", weapon.Name);
        Assert.Equal(15, weapon.Damage);
        Assert.Equal(ItemCategory.Weapon, weapon.Category);
    }

    [Fact]
    public void Builder_CreatesPotionWithHealing()
    {
        var potion = new PotionBuilder()
            .Named("Лечебное зелье")
            .Healing(30)
            .Build();

        Assert.Equal("Лечебное зелье", potion.Name);
        Assert.Equal(30, potion.HealAmount);
        Assert.Equal(ItemCategory.Potion, potion.Category);
    }

    [Fact]
    public void Builder_CreatesArmorWithDefense()
    {
        var armor = new ArmorBuilder()
            .Named("Латная броня")
            .WithDefense(12)
            .Build();

        Assert.Equal("Латная броня", armor.Name);
        Assert.Equal(12, armor.Defense);
        Assert.Equal(ItemCategory.Armor, armor.Category);
    }

    [Fact]
    public void Builder_CreatesQuestItem()
    {
        var questItem = new QuestItemBuilder()
            .Named("Карта сокровищ")
            .ForQuest("Поиск клада")
            .Build();

        Assert.Equal("Карта сокровищ", questItem.Name);
        Assert.Equal("Поиск клада", questItem.QuestName);
        Assert.Equal(ItemCategory.Quest, questItem.Category);
    }

    [Fact]
    public void Inventory_AddsAndFindsItems()
    {
        var inventory = new Inventory();
        var weapon = new WeaponBuilder().Named("Меч").Build();

        inventory.Add(weapon);
        var found = inventory.Use(weapon.Id);

        Assert.False(found.Success);
    }

    [Fact]
    public void Inventory_EquipsWeapon()
    {
        var inventory = new Inventory();
        var weapon = new WeaponBuilder().Named("Меч").Build();
        inventory.Add(weapon);

        inventory.Equip(weapon.Id);
        var description = inventory.Describe();

        Assert.Contains("Меч", description);
        Assert.Contains("Надето", description);
    }
   
    [Fact]
    public void Inventory_UsesPotion()
    {
        var inventory = new Inventory();
        var potion = new PotionBuilder().Named("Зелье").Healing(20).Build();
        inventory.Add(potion);

        var result = inventory.Use(potion.Id);

        Assert.True(result.Success);
        Assert.Equal("Восстановлено 20 здоровья", result.Message);
        Assert.Equal(20, result.Value);
        Assert.True(((Potion)potion).IsSpent); 
    }

    [Fact]
    public void Inventory_UsesQuestItem()
    {
        var inventory = new Inventory();
        var questItem = new QuestItemBuilder()
            .Named("Ключ")
            .ForQuest("Дверь")
            .Build();
        inventory.Add(questItem);

        var result = inventory.Use(questItem.Id);

        Assert.True(result.Success);
        Assert.Contains("Ключ", result.Message);     
        Assert.Contains("Дверь", result.Message);     
    }

    [Fact]
    public void Factory_CreatesEpicWeapon()
    {
        var factory = new SimpleItemFactory();
        var weapon = factory.CreateWeapon("Эпический меч", true);

        Assert.Equal(Rarity.Epic, weapon.Rarity);
        Assert.True(weapon.Damage > 10);
    }

    [Fact]
    public void Factory_CreatesCommonWeapon()
    {
        var factory = new SimpleItemFactory();
        var weapon = factory.CreateWeapon("Обычный меч", false);

        Assert.Equal(Rarity.Common, weapon.Rarity);
        Assert.Equal(10, weapon.Damage);
    }

    [Fact]
    public void UpgradeStrategy_ImprovesWeapon()
    {
        var weapon = new WeaponBuilder()
            .Named("Меч")
            .WithDamage(10)
            .Build();
        var strategy = new SharpenWeaponStrategy(5);

        var result = weapon.UpgradeWith(strategy, null);

        Assert.True(result.Success);
        Assert.Equal(15, weapon.Damage);
        Assert.Equal(1, weapon.UpgradeLevel);
    }

    [Fact]
    public void UpgradeStrategy_CannotUpgradeNonUpgradeable()
    {
        var inventory = new Inventory();
        var questItem = new QuestItemBuilder()
            .Named("Свиток")
            .ForQuest("Магия")
            .Build();
        inventory.Add(questItem);

        var result = inventory.Upgrade(questItem.Id, new SharpenWeaponStrategy());

        Assert.False(result.Success);
        Assert.Contains("Нельзя улучшить", result.Message);
    }

    [Fact]
    public void Inventory_DescribesItems()
    {
        var inventory = new Inventory();
        var weapon = new WeaponBuilder().Named("Меч").Build();
        var potion = new PotionBuilder().Named("Зелье").Build();

        inventory.Add(weapon);
        inventory.Add(potion);
        inventory.Equip(weapon.Id);

        var description = inventory.Describe();

        Assert.Contains("Меч", description);
        Assert.Contains("Зелье", description);
        Assert.Contains("Надето", description);
    }
}