// <copyright file="Misc.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.Initialization.VersionSeasonSix.Items;

using MUnique.OpenMU.DataModel.Configuration;
using MUnique.OpenMU.DataModel.Configuration.Items;

/// <summary>
/// Initializing of misc items which don't fit into the other categories.
/// </summary>
public class Misc : InitializerBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Misc"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="gameConfiguration">The game configuration.</param>
    public Misc(IContext context, GameConfiguration gameConfiguration)
        : base(context, gameConfiguration)
    {
    }

    /// <inheritdoc />
    public override void Initialize()
    {
        this.CreateLifeStone();
        this.CreateGoldenCherryBlossomBranch();
        this.CreateLostMap();
        this.CreateSymbolOfKundun();
        this.CreateSilverKey();
        this.CreateGoldKey();
        this.CreateSealedSilverBox();
        this.CreateSealedGoldenBox();
        this.CreateSilverBox();
        this.CreateGoldenBox();
    }

    private void CreateLostMap()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Lost Map";
        itemDefinition.Number = 28;
        itemDefinition.Group = 14;
        itemDefinition.DropsFromMonsters = false;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.MaximumItemLevel = 7;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateSymbolOfKundun()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Symbol of Kundun";
        itemDefinition.Number = 29;
        itemDefinition.Group = 14;
        itemDefinition.DropLevel = 0;
        itemDefinition.DropsFromMonsters = false;
        itemDefinition.Durability = 5;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.MaximumItemLevel = 7;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);

        /* Drop Levels:
           Symbol +1: Monster Level 25 ~ 46
           Symbol +2: Monster Level 47 ~ 65
           Symbol +3: Monster Level 66 ~ 77
           Symbol +4: Monster Level 78 ~ 84
           Symbol +5: Monster Level 85 ~ 91
           Symbol +6: Monster Level 92 ~ 107
           Symbol +7: Monster Level 108+
        */
        (byte, byte)[] dropLevels = [(25, 46), (47, 65), (66, 77), (78, 84), (85, 91), (92, 107), (108, 255)];
        for (byte level = 1; level <= dropLevels.Length; level++)
        {
            var dropItemGroup = this.Context.CreateNew<DropItemGroup>();
            dropItemGroup.SetGuid(14, 29, level);
            dropItemGroup.ItemLevel = level;
            dropItemGroup.PossibleItems.Add(itemDefinition);
            dropItemGroup.Chance = 0.003; // 0.3 Percent
            dropItemGroup.Description = $"The drop item group for Symbol of Kundun (Level {level})";
            (dropItemGroup.MinimumMonsterLevel, dropItemGroup.MaximumMonsterLevel) = dropLevels[level - 1];

            this.GameConfiguration.DropItemGroups.Add(dropItemGroup);
            BaseMapInitializer.RegisterDefaultDropItemGroup(dropItemGroup);
        }
    }

    private void CreateLifeStone()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Life Stone";
        itemDefinition.Number = 11;
        itemDefinition.Group = 13;
        itemDefinition.DropLevel = 75;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateGoldenCherryBlossomBranch()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Golden Cherry Blossom Branch";
        itemDefinition.Number = 90;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 255;
        itemDefinition.Width = 1;
        itemDefinition.Height = 2;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateSilverKey()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Silver Key";
        itemDefinition.Number = 112;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateGoldKey()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Gold Key";
        itemDefinition.Number = 113;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateSealedSilverBox()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Sealed Silver Box";
        itemDefinition.Number = 122;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateSealedGoldenBox()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Sealed Golden Box";
        itemDefinition.Number = 121;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateSilverBox()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Silver Box";
        itemDefinition.Number = 124;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }

    private void CreateGoldenBox()
    {
        var itemDefinition = this.Context.CreateNew<ItemDefinition>();
        itemDefinition.Name = "Golden Box";
        itemDefinition.Number = 123;
        itemDefinition.Group = 14;
        itemDefinition.Durability = 1;
        itemDefinition.Width = 1;
        itemDefinition.Height = 1;
        itemDefinition.SetGuid(itemDefinition.Group, itemDefinition.Number);
        this.GameConfiguration.Items.Add(itemDefinition);
    }
}
