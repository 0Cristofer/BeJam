using TMPro;
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

        [field: SerializeField]
        private TextMeshProUGUI EndGameText { get; set; }

        private void Start()
        {
            RestartButton.onClick.AddListener(StartGame);
            BackButton.onClick.AddListener(Exit);
            
            EndGameText.text = EndGameManager.DidWin ? "You Win!" : "You Lose!";
            EndGameManager.DidWin = false;
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