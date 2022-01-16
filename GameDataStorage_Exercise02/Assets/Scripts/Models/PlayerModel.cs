using System;
using UnityEngine;

namespace Assets.Models
{
    [CreateAssetMenu(menuName = "Exercise02/Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private int _coinsBalance;

        [SerializeField]
        private int _gemsBalance;

        #endregion

        #region Events

        public event Action<int> CoinsBalanceChange;

        public event Action<int> GemsBalanceChange;

        #endregion

        #region Methods

        public void Initialize(int coins, int gems)
        {
            _coinsBalance = coins;
            _gemsBalance = gems;
        }

        public void AddCoins(int coinsToAdd)
        {
            _coinsBalance += coinsToAdd;
            CoinsBalanceChange?.Invoke(_coinsBalance);
        }

        public void WithdrawCoins(int coinsToWithdraw)
        {
            if (coinsToWithdraw <= _coinsBalance)
            {
                _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
                CoinsBalanceChange?.Invoke(_coinsBalance);
            }
            else
            {
                Debug.Log("Not Enough Coins!");
            }
        }

        public void AddGems(int gemsToAdd)
        {
            _gemsBalance += gemsToAdd;
            GemsBalanceChange?.Invoke(_gemsBalance);
        }

        public void WithdrawGems(int gemsToWithdraw)
        {
            if (gemsToWithdraw <= _gemsBalance)
            {
                _gemsBalance = Mathf.Max(0, _gemsBalance - gemsToWithdraw);
                GemsBalanceChange?.Invoke(_gemsBalance);
            }
            else
            {
                Debug.Log("Not Enough Gems!");
            }
        }

        #endregion

        #region Properties

        public int CoinsBalance => _coinsBalance;
        public int GemsBalance => _gemsBalance;

        #endregion
    }
}
