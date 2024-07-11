using UnityEngine;

namespace TombOfTheMaskClone
{
    public class UIShopInit : MonoBehaviour
    {
        [SerializeField] UIShopData uIShopData;
        [SerializeField] UIShopBuy uIShopBuy;
        void Start()
        {
            uIShopData.Initialize();
            uIShopBuy.Initialize(uIShopData);
        }
    }
}
