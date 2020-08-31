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
    [SerializeField] float fadeOutTime = 1f;
    [SerializeField] float fadeWaitTime = 0.5f;
    [SerializeField] float fadeInTime = 2f;

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

      Fader fader = FindObjectOfType<Fader>();

      yield return fader.FadeOut(fadeOutTime);
      yield return SceneManager.LoadSceneAsync(SceneToLoad);

      Portal otherPortal = GetOtherPortal();
      UpdatePlayer(otherPortal);

      yield return new WaitForSeconds(fadeWaitTime);
      yield return fader.FadeIn(fadeInTime);
      
      Destroy(gameObject);
    }

    private void UpdatePlayer(Portal otherPortal)
       {
         GameObject player = GameObject.FindWithTag("Player");
         
         
         player.transform.position = otherPortal.spawnPoint.position;
         player.transform.rotation = otherPortal.spawnPoint.rotation;

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

