using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;


namespace RPG.Combat
{


    public class Fighter : MonoBehaviour
    {
        [SerializeField] float meleeRange = 2f;
        Transform target;

        private void Update()
        {
            bool isInRange = Vector3.Distance(transform.position, target.position) < meleeRange;
            if (target != null && !isInRange)
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }
    }
}
