using Assets.Infastructure;
using Assets.Models;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Infastructure
{
    public class PlayerDataManager
    {
        #region Fields

        private static PlayerDataManager _instance;

        #endregion

        #region Constructors

        private PlayerDataManager()
        {
            SubscribeToEvents();
        }

        #endregion

        #region Methods

        private void OnSaveCoinsToPref(int coins)
        {

        }

        private void OnSaveGemssToPref(int gems)
        {

        }

        private void SubscribeToEvents()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.CoinsBalanceChange += OnSaveCoinsToPref;
            playerModel.GemsBalanceChange += OnSaveGemssToPref;
        }

        public void SaveToPlayerPrefs()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            PlayerPrefs.SetInt("coins", playerModel.CoinsBalance);
            PlayerPrefs.SetInt("gems", playerModel.GemsBalance);
            PlayerPrefs.Save();
            Debug.Log("Saved to PlayerPrefs!");
        }

        public void LoadPlayerPrefs()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            playerModel.Initialize(PlayerPrefs.GetInt("coins"), PlayerPrefs.GetInt("gems"));
            Debug.Log("Loaded from PlayerPrefs!");
        }

        public void SaveToLocalFile()
        {
            var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
            string json = JsonUtility.ToJson(playerModel);
            File.WriteAllText(Application.dataPath + "/save.txt", json);

            Debug.Log("Saved!");
        }

        public void LoadLocalFile()
        {
            if (File.Exists(Application.dataPath + "/save.txt"))
            {
                string json = File.ReadAllText(Application.dataPath + "/save.txt");
                Debug.Log("Loaded: " + json);

                var playerModel = PlayerModelProvider.Instance.CurrentSaveOption;
                JsonUtility.FromJsonOverwrite(json, playerModel);


                playerModel.Initialize(playerModel.CoinsBalance, playerModel.GemsBalance);
            }
            else
            {
                Debug.Log("No Save!");
            }
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
