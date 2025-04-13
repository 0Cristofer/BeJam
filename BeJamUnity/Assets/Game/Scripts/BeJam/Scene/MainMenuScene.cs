using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BeJam
{
    public class MainMenuScene : MonoBehaviour
    {
        [field: SerializeField]
        private Button StartButton { get; set; }
        
        [field: SerializeField]
        private Button ExitButton { get; set; }

        private void Start()
        {
            StartButton.onClick.AddListener(StartGame);
            ExitButton.onClick.AddListener(Exit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Level1");
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}