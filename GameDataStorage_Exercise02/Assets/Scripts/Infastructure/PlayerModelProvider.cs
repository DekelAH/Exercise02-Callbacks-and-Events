using Assets.Models;
using UnityEngine;

namespace Assets.Infastructure
{
    public sealed class PlayerModelProvider
    {
        #region Fields

        private static PlayerModelProvider _instance;

        private static PlayerModel _playerModel;

        private const string PLAYER_MODEL_RESOURCE_NAME = "Player Model";

        #endregion

        #region Constructors

        public PlayerModelProvider(string playerModelResourceName)
        {
            _playerModel = Resources.Load<PlayerModel>(playerModelResourceName);
        }

        #endregion

        #region Properties

        public static PlayerModelProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerModelProvider(PLAYER_MODEL_RESOURCE_NAME);
                }

                return _instance;
            }
        }

        public PlayerModel PlayerModel => _playerModel;

        #endregion
    }
}
