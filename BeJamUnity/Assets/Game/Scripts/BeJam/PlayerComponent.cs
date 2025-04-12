using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeJam
{
    public class PlayerComponent : MonoBehaviour, IHidableEntity
    {
        public void Hide()
        {
            SceneManager.LoadScene("EndMenu");
        }
    }
}