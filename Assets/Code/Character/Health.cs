using System;
using UnityEngine;

namespace TombOfTheMaskClone
{
    public class Health : MonoBehaviour
    {
        public event Action<int> OnHealthChange;
        [SerializeField] private int startingHealth = 1; // Starting health value, editable in Inspector
        private int health;

        public int CurrentHealth
        {
            get { return health; }
            private set { health = Mathf.Max(value, 0); } // Ensure health never goes below 0
        }

        private void Start()
        {
            health = startingHealth;
            OnHealthChange?.Invoke(health); // Notify listeners about initial health
        }

        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            OnHealthChange?.Invoke(CurrentHealth);
        }
    }
}
