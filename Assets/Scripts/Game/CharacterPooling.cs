using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rebelbyte.Game
{
    /// <summary>
    /// Pool of characters
    /// Spawns characters when there are not any characters queued
    /// </summary>
    public class CharacterPooling
    {
        private Queue<GameObject> characterPool;
        private GameObject[] characterPrefabs;

        public CharacterPooling(GameObject[] prefabs)
        {
            characterPrefabs = prefabs;
            characterPool = new Queue<GameObject>();
        }

        public GameObject GetCharacter()
        {
            if (characterPool.Count == 0)
            {
                GameObject characterPrefab = characterPrefabs[UnityEngine.Random.Range(0, characterPrefabs.Length)];
                GameObject instantiatedGo = Object.Instantiate(characterPrefab);
                return instantiatedGo;
            }

            return characterPool.Dequeue();
        }

        public void RemoveCharacter(GameObject character)
        {
            character.SetActive(false);
            characterPool.Enqueue(character);
        }
    }
}
