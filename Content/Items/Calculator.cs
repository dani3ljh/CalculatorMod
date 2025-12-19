using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalculatorMod.UI;

namespace CalculatorMod.Content.Items
{
	public class Calculator : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.TutorialMod.hjson' file.
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			// Copper Recipe
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.CopperBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			// Tin Recipe
			recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.TinBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override bool? UseItem(Player player)
		{
			if (!Main.dedServ && Main.myPlayer == player.whoAmI) {
				ModContent.GetInstance<UISystem>().ToggleCalculatorUI();
			}

			return true;
		}
	}
}
