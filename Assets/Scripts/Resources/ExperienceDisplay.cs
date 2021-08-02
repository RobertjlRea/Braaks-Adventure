
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Resources
{
    public class ExperienceDisplay : MonoBehaviour
    {
    Experience experince;

    private void Awake()
        {
      experince = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

    private void Update()
        {
       GetComponent<Text>().text = string.Format("{0:0}",  experince.GetPoints());

        }
    }
}
