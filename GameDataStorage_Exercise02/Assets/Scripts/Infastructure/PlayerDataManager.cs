using Assets.Infastructure;
using Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public sealed class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;

        #endregion

        #region Constructors

        public PlayerDataManager()
        {
            var playerModel = PlayerModelProvider.Instance.PlayerModel;
            var coins = PlayerPrefs.GetInt("coins");
            var gems = PlayerPrefs.GetInt("gems");
            playerModel.Initialize(coins, gems);
            SubscribeToEvents();
        }

        #endregion

        #region Methods

        private void OnSaveCoinsToPref(int coins)
        {
            SavePlayerMode();
        }

        private void OnSaveGemssToPref(int gems)
        {
            SavePlayerMode();
        }

        private void SubscribeToEvents()
        {
            var playerModel = PlayerModelProvider.Instance.PlayerModel;
            playerModel.CoinsBalanceChange += OnSaveCoinsToPref;
            playerModel.GemsBalanceChange += OnSaveGemssToPref;
        }

        private void SavePlayerMode()
        {
            var playerModel = PlayerModelProvider.Instance.PlayerModel;
            PlayerPrefs.SetInt("coins", playerModel.CoinsBalance);
            PlayerPrefs.SetInt("gems", playerModel.GemsBalance);
            PlayerPrefs.Save();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateInstance()
        {
            _instance = new PlayerDataManager();
            Debug.Log("Player Data Manager Created");
        }

        #endregion

        #region Properties

        public static PlayerDataManager Instance => _instance;

        #endregion

    }
}
