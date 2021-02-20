using System.Collections;
using System.Collections.Generic;
using Rebelbyte.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rebelbyte.UI
{
    /// <summary>
    /// Class for Hud UI
    /// It gets user configuration on play mode and displays some information.
    /// </summary>
    public class Hud : MonoBehaviour
    {
        #region Inspector Fields

        [Header("Sliders configuration")]
        [SerializeField] private Slider spawnRateSlider;
        [SerializeField] private Slider speedSlider;
        [Header("Information displayed")]
        [SerializeField] private TextMeshProUGUI charactersCount;
        [SerializeField] private TextMeshProUGUI moneyCount;

        #endregion

        #region Private Properties

        private int money = 0;
        private int characters = 0;

        #endregion

        void Start()
        {
            spawnRateSlider.onValueChanged.AddListener(OnSpawnRateChanged);
            speedSlider.onValueChanged.AddListener(OnSpeedChanged);

            GameManager.Instance.OnCharacterSpawned += OnNewCharacter;
            GameManager.Instance.OnCharacterRemoved += OnRemovedCharacter;
            GameManager.Instance.OnItemTaken += OnNewItem;
        }

        #region Events Callbacks
        private void OnSpawnRateChanged(float value)
        {
            GameManager.Instance.SPAWN_RATE = 1 / value;
        }

        private void OnSpeedChanged(float value)
        {
            GameManager.Instance.CHARACTER_SPEED = value;
        }

        private void OnNewCharacter()
        {
            characters++;
            charactersCount.text = characters.ToString();
        }

        private void OnRemovedCharacter(Character.Character character)
        {
            characters--;
            charactersCount.text = characters.ToString();
        }

        private void OnNewItem()
        {
            money += 10;
            moneyCount.text = money.ToString();
        }

        #endregion
    }
}