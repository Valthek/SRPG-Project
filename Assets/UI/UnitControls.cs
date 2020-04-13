using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Entities.Attributes;
using Assets.Entities.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    class UnitControls:MonoBehaviour
    {
        public GameObject GameManager;
        private GameManager _gameManager;

        void Start()
        {
            _gameManager = GameManager.gameObject.GetComponent<GameManager>();
        }

        public void Move()
        {
            if (_gameManager.SelectedUnit != null && _gameManager.SelectedTile != null)
            {
                Debug.Log($"Moving from {_gameManager.SelectedUnit.position} to {_gameManager.SelectedTile.position}" );
                var unit = _gameManager.SelectedUnit.GetComponent<IUnit>();
                unit.Movement.SetDestination(_gameManager.SelectedTile.gameObject.GetComponent<ITile>(), _gameManager.TileEntities);
            }
        }

        public void ChangeText(string test)
        {
            Text text = transform.Find("Text").GetComponent<Text>();
            text.text = test;
        }
    }
}
