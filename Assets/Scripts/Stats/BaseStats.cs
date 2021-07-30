using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
       [Range(1, 99)]
       [SerializeField] int startinglevel = 1;
       [SerializeField] CharacterClass characterClass;   
       [SerializeField] Progression Progression = null;
    

    public float GetHealth()
    {
        return Progression.GetHealth(characterClass, startinglevel);
    }
    
    public float GetExperienceReward()

    {
        return 10;
    }
    
    }

    
}
