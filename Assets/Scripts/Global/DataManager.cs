using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public enum EntityId { Adit,Centipede,Connor,CrystalizedDragon,Dorien,Dragon,HummingBlade,MerakMage,Mikel,MysteriousBandit,PigClone,Rena,Snake,StreetSparrow, WildPig, None }; // This is the list to match the Entities with their name
    public static LevelPackage CurrentLevelPackage;
    public static Vector2[] CharacterPositions = { new Vector2(-1.86f, 2.38f), new Vector2(-4.36f, 1.58f), new Vector2(-7.02f, 0.77f), new Vector2(1.83f, 1.88f), new Vector2(4.35f, 1.1f), new Vector2(6.97f, 0.33f) };
    #region SavedData
    public static int UnlockedLevel;
    public static int Coins;
    public static int Gems;
    #endregion
}