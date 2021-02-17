using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rebelbyte.Game
{
    public enum HappinessLevel
    {
        Green = 0,
        Yellow = 1,
        Red = 2
    }

    /// <summary>
    /// Class for happiness handling
    /// Checks every 10 seconds what happiness level should be
    /// </summary>
    public class HappinessController
    {
        #region Private Properties

        private CancellationTokenSource cancelHappinessControl;

        private int items;

        #endregion

        #region Public Properties

        public HappinessLevel HappinessLevel { get; private set; }
        public Action<HappinessLevel> OnHappinessChanged;

        #endregion

        #region Init

        public HappinessController()
        {
            GameManager.Instance.OnItemTaken += OnNewItem;
            cancelHappinessControl = new CancellationTokenSource();
            CheckHappiness(cancelHappinessControl.Token);
        }

        ~HappinessController()
        {
            GameManager.Instance.OnItemTaken -= OnNewItem;
            cancelHappinessControl.Cancel();
        }

        #endregion

        #region Event Callbacks

        private void OnNewItem()
        {
            items++;
        }

        #endregion

        #region Happiness Managment

        private async Task CheckHappiness(CancellationToken cancel)
        {
            while (true)
            {
                if (cancel.IsCancellationRequested)
                    return;

                await Task.Delay(10000, cancel);

                CalculateHappinessLevel();

                items = 0;
            }
        }

        private void CalculateHappinessLevel()
        {
            if (items > 7)
                HappinessLevel = HappinessLevel.Green;
            else if (items < 2)
                HappinessLevel = HappinessLevel.Yellow;
            else
                HappinessLevel = HappinessLevel.Red;

            OnHappinessChanged?.Invoke(HappinessLevel);
        }

        #endregion
    }
}