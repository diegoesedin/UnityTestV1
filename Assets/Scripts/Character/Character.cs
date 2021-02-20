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
        #region Private Properties

        private NavMeshAgent navAgent;
        private Animator animator;
        private Transform objective;

        #endregion


        #region Unity Methods

        void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
            navAgent.enabled = true;
            animator = GetComponentInChildren<Animator>();
            navAgent.SetDestination(objective.position);

            navAgent.speed = GameManager.Instance.CHARACTER_SPEED;
        }

        void OnEnable()
        {
            if (navAgent != null)
            {
                navAgent.enabled = true;
                navAgent.speed = GameManager.Instance.CHARACTER_SPEED;
                if (objective != null)
                    navAgent.SetDestination(objective.position);
            }
        }

        void OnDisable()
        {
            navAgent.enabled = false;
        }

        void Update()
        {
            animator.SetFloat("Blend", navAgent.velocity.magnitude);
        }

        void LateUpdate()
        {
            SearchItem();
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

        #endregion

        #region Character Behaviours

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

        public void InitDestination(Transform destination)
        {
            objective = destination;
        }

        #endregion
    }
}
