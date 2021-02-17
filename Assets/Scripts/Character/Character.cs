using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Rebelbyte.Game;

namespace Rebelbyte.Character
{
    /// <summary>
    /// Character GameObject main class
    /// Manages character animation and AI by Navigator
    /// </summary>
    public class Character : MonoBehaviour
    {
        private NavMeshAgent navAgent;
        private Animator animator;

        public Transform objective;

        void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            navAgent.SetDestination(objective.position);
        }

        void OnEnable()
        {
            if (objective != null)
                navAgent?.SetDestination(objective.position);
        }

        void Update()
        {
            animator.SetFloat("Blend", navAgent.velocity.magnitude);
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Final")
            {
                GameManager.Instance.OnCharacterRemoved?.Invoke(this);
            }
        }

        public void InitDestination(Transform destination)
        {
            objective = destination;
        }
    }
}
