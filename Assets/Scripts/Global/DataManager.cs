using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public enum ItemId { None,Carrot, Lettuce, Potato, Tomato };
    public enum BackroundId { Forest,Minegate,Borderline,Caverns,Grotto,Cennet,Prison};
    public enum EntityId { None, Dorien, Rena, Mikel, Adit, Centipede,Connor,CrystalizedDragon,Dragon,HummingBlade,MerakMage,MysteriousBandit,PigClone,Snake,StreetSparrow, WildPig }; // This is the list to match the Entities with their name
    public static int SelectedLevel = -1; 
    public static LevelPackage CurrentLevelPackage;
    public static Vector2[] CharacterPositions = { new Vector2(-1.86f, 2.38f), new Vector2(-4.36f, 1.58f), new Vector2(-7.02f, 0.77f), new Vector2(1.83f, 1.88f), new Vector2(4.35f, 1.1f), new Vector2(6.97f, 0.33f) };
    public static int[] CharacterSelectorData = new int[3];

    #region SavedData
    public static int UnlockedLevel;
    public static int Coins;
    public static int Gems;
    public static ItemStack[] StoredInventory = new ItemStack[16];
    public static ItemStack[] Inventory = new ItemStack[9];
    #endregion
}