using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BeJam
{
    public class EndMenuScene : MonoBehaviour
    {
        [field: SerializeField]
        private Button RestartButton { get; set; }
        
        [field: SerializeField]
        private Button BackButton { get; set; }

        private void Start()
        {
            RestartButton.onClick.AddListener(StartGame);
            BackButton.onClick.AddListener(Exit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Level1");
        }

        private void Exit()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}