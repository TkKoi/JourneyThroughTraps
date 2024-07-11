using UnityEngine;

namespace TombOfTheMaskClone
{
     [CreateAssetMenu(fileName = "ShopDB", menuName = "Shop/DataBase")]
    public class ShopDatabase : ScriptableObject
    {
        public PlayerMovement[] player;
    }
}
