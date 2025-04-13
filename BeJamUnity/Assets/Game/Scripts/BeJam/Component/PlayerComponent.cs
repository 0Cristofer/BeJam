using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeJam
{
    public class PlayerComponent : MonoBehaviour, ICoverableEntity
    {
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