using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace GoldenAppleMod
{
    public class GoldenAppleMod : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.RegisterItemClass("ItemGoldenApple", typeof(ItemGoldenApple));
        }
    }

    public class ItemGoldenApple : Item
    {
        public override void OnConsumedBy(EntityAgent consumer, ItemSlot slot, EnumConsumableType consumableType)
        {
            base.OnConsumedBy(consumer, slot, consumableType);

            if (consumer is EntityPlayer player)
            {
                IPlayer byPlayer = (consumer.World.Api as ICoreServerAPI)?.World.PlayerByUid((consumer as EntityPlayer).PlayerUID);
                if (byPlayer != null)
                {
                    // Restore half of the player's health
                    float healthToRestore = 10f;  // Restores 5 hearts
                    byPlayer.Entity.ReceiveDamage(new DamageSource() { Type = EnumDamageType.Heal }, -healthToRestore);
                }
            }
        }
    }
}
