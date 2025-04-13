using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeJam
{
    public class PlayerComponent : MonoBehaviour, ICoverableEntity
    {
        public void OnCovered()
        {
            SceneManager.LoadScene("EndMenu");
        }
    }
}