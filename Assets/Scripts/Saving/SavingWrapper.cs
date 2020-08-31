using UnityEngine;

namespace RPG.Saving
{
public class SavingWrapper : MonoBehaviour 
{
  const string defaultSaveFile = "save";
     
     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.F3))
         {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
         }
        
        if (Input.GetKeyDown(KeyCode.F4))
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }

     }
}
}
