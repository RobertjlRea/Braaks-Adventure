using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        

        NavMeshAgent navMeshAgent;


        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Start is called before the first frame update

        void Update()
        {
            UpdateAnimator();

        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);

        }



        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }
    }
}
