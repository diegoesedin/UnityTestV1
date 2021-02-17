using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Rebelbyte.Game;
using Rebelbyte.Items;

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

            SearchItem();
        }

        /// <summary>
        /// Check for items in a radius, if character founds one, character will go for it
        /// </summary>
        private void SearchItem()
        {
            Collider[] someItem = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Item"));
            if (someItem.Length > 0)
            {
                navAgent.SetDestination(someItem[0].transform.position);
            }
            else
            {
                navAgent?.SetDestination(objective.position);
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Item")
            {
                collider.gameObject.GetComponent<Item>().TakeItem();
                navAgent.SetDestination(objective.position);
            }

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
