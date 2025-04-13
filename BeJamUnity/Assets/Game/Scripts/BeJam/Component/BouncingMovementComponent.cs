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

        private void Start()
        {
            CurrentVelocity = StartVelocity;
            Rigidbody2D.linearVelocity = CurrentVelocity;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PostIt>() != null)
            {
                return;
            }
            
            if (other.gameObject.transform.position.x > 0)
            {
                CurrentVelocity = new Vector2(-CurrentVelocity.x, CurrentVelocity.y);
            }
            else if (other.gameObject.transform.position.x < 0)
            {
                CurrentVelocity = new Vector2(-CurrentVelocity.x, CurrentVelocity.y);
            }
            else if (other.gameObject.transform.position.y > 0)
            {
                CurrentVelocity = new Vector2(CurrentVelocity.x, -CurrentVelocity.y);
            }
            else if (other.gameObject.transform.position.y < 0)
            {
                CurrentVelocity = new Vector2(CurrentVelocity.x, -CurrentVelocity.y);
            }
            
            Rigidbody2D.linearVelocity = CurrentVelocity;
        }
    }
}
