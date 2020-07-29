using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using UnityEngine.Rendering;
using RPG.Core;

namespace RPG.Combat
{


    public class Fighter : MonoBehaviour
    {
        [SerializeField] float meleeRange = 2f;
        Transform target;

        private void Update()
        {
            if (target == null) return;
                {
                    if (!GetIsInRange())
                    {
                        GetComponent<Mover>().MoveTo(target.position);
                    }
                    else
                    {
                        GetComponent<Mover>().Stop();
                    }
                }
        }

        private bool GetIsInRange()
        {
          return Vector3.Distance(transform.position, target.position) < meleeRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}
