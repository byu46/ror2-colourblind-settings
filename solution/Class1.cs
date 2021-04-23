using BepInEx;
using RoR2;

namespace byu46
{
    //Change these
    [BepInPlugin("com.byu46.ColourblindSettings", "ColourblindSettings", "1.0.0")]
    public class ColourblindSettings : BaseUnityPlugin
    {
        public void Awake()
        {
            var newTier2ItemColour = new UnityEngine.Color32(198, 118, 67, byte.MaxValue);
            var newTier2ItemDarkColour = new UnityEngine.Color32(139, 69, 19, byte.MaxValue);
            var newEquipmentItemColour = new UnityEngine.Color32(128, 0, 128, byte.MaxValue);
            Logger.LogMessage("Loaded ColourblindSettings!");

            On.RoR2.ColorCatalog.GetColor += (orig, self) =>
            {
                switch (self)
                {
                    case ColorCatalog.ColorIndex.Tier2Item:
                        return newTier2ItemColour;
                    case ColorCatalog.ColorIndex.Equipment:
                        return newEquipmentItemColour;
                    case ColorCatalog.ColorIndex.Tier2ItemDark:
                        return newTier2ItemDarkColour;
                    default:
                        return orig(self);
                }
            };

            On.RoR2.ColorCatalog.GetColorHexString += (orig, self) =>
            {
                switch (self)
                {
                    case ColorCatalog.ColorIndex.Tier2Item:
                        return Util.RGBToHex(newTier2ItemColour);
                    case ColorCatalog.ColorIndex.Equipment:
                        return Util.RGBToHex(newEquipmentItemColour);
                    case ColorCatalog.ColorIndex.Tier2ItemDark:
                        return Util.RGBToHex(newTier2ItemDarkColour);
                    default:
                        return orig(self);
                }
            };
        }
    }
}