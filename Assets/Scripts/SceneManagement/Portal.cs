using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace RPG.SceneManagement
{
public class Portal : MonoBehaviour
{  
    enum DestinationIdentifier
    {
      A, B, C, D, E
    }

    [SerializeField] int SceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIdentifier Destination;
  private void OnTriggerEnter(Collider other)
   {
        if (other.tag == "Player")
        {
         StartCoroutine(Transition());
        
        }

        
  }
    private IEnumerator Transition()
    {
      if (SceneToLoad < 0)
      {
         Debug.LogError("Scene to load not set");
         yield break;
      }
      DontDestroyOnLoad(gameObject);
      yield return SceneManager.LoadSceneAsync(SceneToLoad);

      Portal otherPortal = GetOtherPortal();
      UpdatePlayer(otherPortal);
      
      Destroy(gameObject);
    }

    private void UpdatePlayer(Portal otherPortal)
       {
         GameObject player = GameObject.FindWithTag("Player");
         
         

       }

        private Portal GetOtherPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
         {
          if (portal == this) continue;
          if (portal.Destination != Destination) continue;
          return portal;
         }
          return null;
        }
     
  }
}

