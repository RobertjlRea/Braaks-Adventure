using UnityEngine;
using RPG.Saving;
using RPG.Core;
using RPG.Stats;

namespace RPG.Resources
{
    
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints = 100f;

        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetHealth();
        }

        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(GameObject instigator, float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            
          if (healthPoints == 0)
            {
                Die();
                AwardExperience(instigator);
            }

        }

        public float GetPercentage()

        {
            return 100 *  healthPoints / GetComponent<BaseStats>().GetHealth();
        }

        private void Die()
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AwardExperience(GameObject instigator)

        {
            Experience experience = instigator.GetComponent<Experience>();

            if(experience == null) return;

            experience.GainExperience(GetComponent<BaseStats>().GetExperienceReward());
        }
        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
                healthPoints = (float) state;

                if(healthPoints <= 0)
                {
                    Die();
                }
        }
    }
}
