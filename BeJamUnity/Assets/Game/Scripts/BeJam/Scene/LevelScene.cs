using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BeJam
{
    public class LevelScene : MonoBehaviour
    {
        [field: SerializeField]
        private Button BackButton { get; set; }
        
        private void Start()
        {
            BackButton.onClick.AddListener(Back);
        }
        
        private void Back()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}