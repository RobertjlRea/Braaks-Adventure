using System.Collections;
using RPG.Saving;
using UnityEngine;

namespace RPG.SceneManagement
{
public class SavingWrapper : MonoBehaviour 
{
   [SerializeField] float fadeInTime = 0.2f;
  const string defaultSaveFile = "save";

  private IEnumerator Start()
  {
     Fader fader = FindObjectOfType<Fader>();

     fader.FadeOutImmediate();
    yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);
    yield return fader.FadeIn(fadeInTime);
  }
     
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
