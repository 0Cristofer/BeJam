using UnityEngine;

namespace BeJam
{
    public class EnemyComponent : MonoBehaviour, IHidableEntity
    {
        public void Hide()
        {
            Destroy(gameObject);
        }
    }
}