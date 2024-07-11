using UnityEngine;

namespace JourneyThroughTraps
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
