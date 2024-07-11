using UnityEngine;

namespace JourneyThroughTraps
{
    public class ComponentDestroy : MonoBehaviour
    {
        [SerializeField] MonoBehaviour[] monoBehaviour;

        public void DisableAllComponents()
        {
            foreach (var component in monoBehaviour)
            {
                component.enabled = false;
            }
        }

        public void EnableAllComponents()
        {
            foreach (var component in monoBehaviour)
            {
                component.enabled = true;
            }
        }
    }
}
