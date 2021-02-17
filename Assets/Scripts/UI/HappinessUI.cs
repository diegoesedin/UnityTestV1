using System.Collections;
using System.Collections.Generic;
using Rebelbyte.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Rebelbyte.UI
{
    /// <summary>
    /// Class for Happiness indicator on UI
    /// It changes icon and color depending on happiness level (@HappinessController)
    /// </summary>
    public class HappinessUI : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Images on UI")]
        [SerializeField] private Image happinessIcon;
        [SerializeField] private Image happinessBorder;
        [Header("Happiness configuration")]
        [SerializeField] private Sprite[] moodSprites;
        [SerializeField] private Color[] moodColors;

        #endregion

        private HappinessController happinessController;

        void Start()
        {
            happinessController = new HappinessController();
            happinessController.OnHappinessChanged += UpdateIndicator;
        }

        private void UpdateIndicator(HappinessLevel level)
        {
            happinessIcon.sprite = moodSprites[(int)level];
            happinessBorder.color = moodColors[(int)level];
        }
    }
}