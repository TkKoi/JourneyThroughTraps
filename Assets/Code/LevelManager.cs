using UnityEngine;

namespace TombOfTheMaskClone
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Character Spawn Setting")]
        [SerializeField] ShopDatabase _shopDatabase;
        [SerializeField] Transform _playerSpawnPosition; // Position where the player's spaceship will spawn


        private void Awake()
        {
            SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            // Check if the spaceship database and the array of spaceships are properly initialized
            if (_shopDatabase != null && _shopDatabase.player != null && _shopDatabase.player.Length > PlayerPrefs.GetInt("SelectedShipIndex"))
            {
                // Instantiate the player's spaceship at the spawn position based on the selected ship index
                Instantiate(_shopDatabase.player[PlayerPrefs.GetInt("SelectedShipIndex")], _playerSpawnPosition.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("SpaceshipDatabase or _spaceShip array is not properly initialized.");
            }
        }
    }
}
