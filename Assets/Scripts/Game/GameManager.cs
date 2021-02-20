using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rebelbyte.Game
{
    /// <summary>
    /// No superclass intended!!
    /// This "GameManager" is only a singleton to centralize game flow, events and global data for this too short gameplay.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        #region GLOBAL CONFIGURATION

        public float SPAWN_RATE { get; set; } = 1 / 0.1f;
        public float CHARACTER_SPEED { get; set; } = 3;

        #endregion

        #region GAME EVENTS

        public Action OnCharacterSpawned;
        public Action<Character.Character> OnCharacterRemoved;
        public Action OnItemTaken;

        #endregion


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
                Destroy(this);
        }
    }
}