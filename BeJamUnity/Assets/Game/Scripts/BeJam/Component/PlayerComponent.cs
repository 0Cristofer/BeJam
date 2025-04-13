using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeJam
{
    public class PlayerComponent : MonoBehaviour, ICoverableEntity
    {
        [field: SerializeField]
        private BouncingMovementComponent BouncingMovement { get; set; }
        
        [field: SerializeField]
        private Vector2 MinVelocity { get; set; }
        
        [field: SerializeField]
        private Vector2 MaxVelocity { get; set; }

        private void Start()
        {
            var velocityX = Random.Range(MinVelocity.x, MaxVelocity.x);
            var velocityY = Random.Range(MinVelocity.y, MaxVelocity.y);
            
            BouncingMovement.SetVelocity(new Vector2(velocityX, velocityY));
        }

        public void OnCovered()
        {
            EndGameManager.DidWin = false;
            SceneManager.LoadScene("EndMenu");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.gameObject.GetComponent<EnemyComponent>();
            
            if (enemy == null)
                return;
            
            EndGameManager.DidWin = false;
            SceneManager.LoadScene("EndMenu");
        }
    }
}