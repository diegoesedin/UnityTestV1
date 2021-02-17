using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rebelbyte.Game;
using UnityEngine;

namespace Rebelbyte.Items
{
    /// <summary>
    /// Class for Item gameobject
    /// </summary>
    public class Item : MonoBehaviour
    {
        private readonly int SECONDS_TO_RESPAWN = 10;

        private CancellationTokenSource cancelRespawn;

        void Start()
        {
            cancelRespawn = new CancellationTokenSource();
        }

        public void TakeItem()
        {
            gameObject.SetActive(false);
            GameManager.Instance.OnItemTaken?.Invoke();
            ReSpawnItem(cancelRespawn.Token);
        }

        /// <summary>
        /// After X seconds, Item will appear again
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        private async Task ReSpawnItem(CancellationToken cancel)
        {
            if (cancel.IsCancellationRequested)
                return;

            await Task.Delay(SECONDS_TO_RESPAWN * 1000, cancel);

            this.gameObject.SetActive(true);
        }

        void OnDestroy()
        {
            cancelRespawn.Cancel();
        }
    }
}
