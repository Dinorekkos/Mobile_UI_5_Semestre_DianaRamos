using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
   public int starsCollected = 0;


   [Button]
   public void TestSaveStars()
   {
      PlayerPrefs.SetInt(SaveKeys.StarsCollected, starsCollected);
      PlayerPrefs.Save();
      
   }

   [Button]
   public void TestReadStarsValue()
   {
      starsCollected = PlayerPrefs.GetInt(SaveKeys.StarsCollected, 0);
      Debug.Log(SaveKeys.StarsCollected + starsCollected);
   }


}

public static class SaveKeys
{
   public const string StarsCollected = "StarsCollected";
}