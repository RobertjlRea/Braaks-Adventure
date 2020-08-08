using System;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;

namespace RPG.Control
{

    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 10f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float waypointTolerance = 1f;
        
        [SerializeField] float DwellTime = 3f;
         [Range(0,1)]
        [SerializeField] float patrolspeedFraction = 0.2f;

// GameObject Components
        Fighter fighter;
        Health health;
        GameObject player;
        Mover mover;
        
        Vector3 guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float  LastMoved = Mathf.Infinity;

        int currentWaypointIndex = 0;

        private void Start() 
        {
          fighter = GetComponent<Fighter>();
          mover   =  GetComponent<Mover>();
          health  = GetComponent<Health>();
          player  = GameObject.FindWithTag("Player");
          

          guardPosition = transform.position;
          
          
          
        }
        private void Update()
        {
            if (health.IsDead()) return;

            if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();

            }

            // will chase for a short time after losing
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                PatrolBehaviour();
            }

            UpdateTimers();

        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            LastMoved += Time.deltaTime;
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        // called by unity
        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        private void AttackBehaviour()
        {
            fighter.Attack(player);
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }


        //Patroling Methods
        private void PatrolBehaviour()
        {
            
            Vector3 nextPosition = guardPosition;

            if(patrolPath != null)
            {
             if (LastMoved > DwellTime)
                if(AtWaypoint())
                {
                    LastMoved = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
               
            }
             mover.StartMoveAction(nextPosition, patrolspeedFraction);
        }
             private bool AtWaypoint()
             {
               
                 float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
                 return distanceToWaypoint < waypointTolerance;
             }

             private void CycleWaypoint()
             {
               
                    currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
             }

             private Vector3 GetCurrentWaypoint()
             {
               return patrolPath.GetWaypoint(currentWaypointIndex);
             }
        
    }

}