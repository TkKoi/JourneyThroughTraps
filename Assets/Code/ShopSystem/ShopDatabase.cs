using UnityEngine;

namespace JourneyThroughTraps
{
     [CreateAssetMenu(fileName = "ShopDB", menuName = "Shop/DataBase")]
    public class ShopDatabase : ScriptableObject
    {
        public PlayerMovement[] player;
    }
}
