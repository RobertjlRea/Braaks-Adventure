﻿using UnityEngine;

namespace RPG.Stats

{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0 )]
    public class Progression : ScriptableObject 
    
    {

    [SerializeField] ProgressionCharacterClass[] characterClasses = null; 
   
    public float GetStat(Stat stat, CharacterClass characterClass, int level)

    {
        foreach (ProgressionCharacterClass progressionClass in characterClasses)
        {
            if (progressionClass.characterClass != characterClass ) continue;

            foreach(ProgressionStat ProgressionStat in progressionClass.stats)
            {
            if(ProgressionStat.stat != stat) continue;

            if(ProgressionStat.levels.Length < level) continue;

            return ProgressionStat.levels[level -1];
            }
        
        }
        return 0;
    }

     [System.Serializable]
     class ProgressionCharacterClass
    {
        public CharacterClass characterClass;
        public ProgressionStat[] stats;

    }

    [System.Serializable]
     class ProgressionStat
     {
         public Stat stat;
         public float[] levels;
     }

}
}
