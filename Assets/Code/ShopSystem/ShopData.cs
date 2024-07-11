using UnityEngine;

namespace TombOfTheMaskClone
{
    [CreateAssetMenu(fileName = "New Shop Data", menuName = "Shop/Data")]
    public class ShopData : ScriptableObject
    {
        public Sprite icon;
        public int price;
    }
}
