using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeJam
{
    public class EnemyComponent : MonoBehaviour, ICoverableEntity
    {
        [field: SerializeField]
        private BouncingMovementComponent BouncingMovement { get; set; }
        
        [field: SerializeField]
        private Rigidbody2D Rigidbody2D { get; set; }

        [field: SerializeField]
        private Vector2 MinVelocity { get; set; }
        
        [field: SerializeField]
        private Vector2 MaxVelocity { get; set; }
        
        public void Init(Vector2 spawnPosition)
        {
            Rigidbody2D.position = new Vector3(spawnPosition.x, spawnPosition.y, -1f);
            
            var velocityX = Random.Range(MinVelocity.x, MaxVelocity.x);
            var velocityY = Random.Range(MinVelocity.y, MaxVelocity.y);
            
            BouncingMovement.SetVelocity(new Vector2(velocityX, velocityY));
        }
        
        public void OnCovered()
        {
            Destroy(gameObject);
            EndGameManager.TotalEnemies--;

            if (EndGameManager.TotalEnemies != 0)
                return;
            
            EndGameManager.DidWin = true;
            SceneManager.LoadScene("EndMenu");
        }
    }
}