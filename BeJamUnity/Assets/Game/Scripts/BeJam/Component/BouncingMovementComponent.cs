using UnityEngine;

namespace BeJam
{
    public class BouncingMovementComponent : MonoBehaviour
    {
        [field: SerializeField]
        private Rigidbody2D Rigidbody2D { get; set; }

        [field: SerializeField] 
        private Vector2 StartVelocity { get; set; }
        
        [field: SerializeField] 
        private Vector2 CurrentVelocity { get; set; }

        public void SetVelocity(Vector2 velocity)
        {
            StartVelocity = velocity;
            CurrentVelocity = velocity;
            Rigidbody2D.linearVelocity = CurrentVelocity;
        }
        
        private void Start()
        {
            SetVelocity(StartVelocity);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PostIt>() != null)
            {
                return;
            }
            
            if (other.GetComponent<EnemyComponent>() != null)
            {
                return;
            }
            
            if (other.GetComponent<EnemySpawner>() != null)
            {
                return;
            }
            
            if (other.gameObject.transform.position.x > 0)
            {
                SetVelocity(new Vector2(-CurrentVelocity.x, CurrentVelocity.y));
            }
            else if (other.gameObject.transform.position.x < 0)
            {
                SetVelocity(new Vector2(-CurrentVelocity.x, CurrentVelocity.y));
            }
            else if (other.gameObject.transform.position.y > 0)
            {
                SetVelocity(new Vector2(CurrentVelocity.x, -CurrentVelocity.y));
            }
            else if (other.gameObject.transform.position.y < 0)
            {
                SetVelocity(new Vector2(CurrentVelocity.x, -CurrentVelocity.y));
            }
        }
    }
}
