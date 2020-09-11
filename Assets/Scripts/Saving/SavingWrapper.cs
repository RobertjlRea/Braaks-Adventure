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
            Save();
         }
        
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Load();
        }

     }

     public void Save()
     {
        GetComponent<SavingSystem>().Save(defaultSaveFile);
        
     }

     public void Load()
     {
        GetComponent<SavingSystem>().Load(defaultSaveFile);
     }
}
}