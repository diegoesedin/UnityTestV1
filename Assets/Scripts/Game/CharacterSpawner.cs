using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Rebelbyte.Game
{
    /// <summary>
    /// Class for world point to manage spawn
    /// </summary>
    public class CharacterSpawner : MonoBehaviour
    {
        [Header("Characters to be spawned")]
        [SerializeField] private GameObject[] characterPrefabs;
        [Header("World point where characters will go")]
        [SerializeField] private Transform destination;

        private CancellationTokenSource cancelSpawn;
        private CharacterPooling spawnPool;

        void Start()
        {
            spawnPool = new CharacterPooling(characterPrefabs);
            cancelSpawn = new CancellationTokenSource();

            GameManager.Instance.OnCharacterRemoved += RemoveCharacter;

            Spawn(cancelSpawn.Token);
        }

        void OnDestroy()
        {
            cancelSpawn.Cancel();
        }

        /// <summary>
        /// Spawns a character every X seconds
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        private async Task Spawn(CancellationToken cancel)
        {
            while (true)
            {
                if (cancel.IsCancellationRequested)
                    return;

                GameObject spawnedCharacter = spawnPool.GetCharacter();
                spawnedCharacter.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                spawnedCharacter.SetActive(true);
                spawnedCharacter.GetComponent<Character.Character>().InitDestination(destination);

                await Task.Delay((int)(1 * 1000), cancel);
            }
        }

        /// <summary>
        /// Remove character putting it on the pool again
        /// </summary>
        /// <param name="character"></param>
        private void RemoveCharacter(Character.Character character)
        {
            spawnPool.RemoveCharacter(character.gameObject);
        }
    }
}
