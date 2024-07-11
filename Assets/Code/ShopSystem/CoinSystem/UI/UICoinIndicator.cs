using TMPro;
using UnityEngine;

namespace TombOfTheMaskClone
{
    public class UICoinIndicator : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _coinText;

        private void Start()
        {
            ChangeText(PlayerPrefs.GetInt("Coins"));
        }

        private void OnEnable()
        {
            CoinSystem.OnChangeCoin += ChangeText;
        }

        private void OnDisable()
        {
            CoinSystem.OnChangeCoin -= ChangeText;
        }

        private void ChangeText(int coins)
        {
            _coinText.text = coins.ToString();
        }
    }
}