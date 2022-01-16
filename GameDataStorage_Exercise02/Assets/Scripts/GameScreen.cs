using Assets.Infastructure;
using Assets.Models;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameScreen : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private int _coinsToAdd = 30;
        
        [SerializeField]
        private int _coinsToTake = 30;

        [SerializeField]
        private int _gemsToAdd = 1;

        [SerializeField]
        private int _gemsToTake = 1;
        
        #endregion
        
        #region Methods

        private PlayerModel SetPlayerModel()
        {
            var playerModel = PlayerModelProvider.Instance.PlayerModel;
            return playerModel;
        }

        public void OnAddCoinsButtonClick()
        {
            var playerModel = SetPlayerModel();
            playerModel.AddCoins(_coinsToAdd);
        }

        public void OnTakeCoinsButtonClick()
        {
            var playerModel = SetPlayerModel();
            playerModel.WithdrawCoins(_coinsToTake);
        }

        public void OnAddGemsButtonClick()
        {
            var playerModel = SetPlayerModel();
            playerModel.AddGems(_gemsToAdd);
        }

        public void OnTakeGemsButtonClick()
        {
            var playerModel = SetPlayerModel();
            playerModel.WithdrawGems(_gemsToTake);
        }

        #endregion
    }
}