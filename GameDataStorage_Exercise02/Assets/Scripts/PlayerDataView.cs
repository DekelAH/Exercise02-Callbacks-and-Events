using Assets.Infastructure;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerDataView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Text _coinsBalance;

        [SerializeField]
        private Text _gemsBalance;

        #endregion

        #region Methods

        private void Start()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var playerModel = PlayerModelProvider.Instance.PlayerModel;

            playerModel.CoinsBalanceChange += OnCoinsBalanceChange;
            playerModel.GemsBalanceChange += OnGemsBalanceChange;

            OnCoinsBalanceChange(playerModel.CoinsBalance);
            OnGemsBalanceChange(playerModel.GemsBalance);

        }

        private void OnCoinsBalanceChange(int coins)
        {
            _coinsBalance.text = coins.ToString();
        }

        private void OnGemsBalanceChange(int gems)
        {
            _gemsBalance.text = gems.ToString();
        }
        
        #endregion
    }
}