using UnityEngine;

namespace BeJam
{
    public class EnemyComponent : MonoBehaviour, ICoverableEntity
    {
        public void OnCovered()
        {
            Destroy(gameObject);
        }
    }
}