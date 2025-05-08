using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverGUI : GUIBase
{
    [Header("Components")]
    [SerializeField]
    private Button playAgainButton;
    public TextMeshProUGUI text;

    [Header("Player")]
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private Vector3 initialPlayerPosition;
    [SerializeField]
    private int initialPlayerHealth = 100;

    private void Start()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainClicked);
    }

    public void GameOver()
    {
        text.text = "Game Over";
        Show(); // Show the Game Over UI
    }

    public void OnPlayAgainClicked()
    {
        Time.timeScale = 1f;
        Hide(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void ResetPlayer()
    {
        // Reset player position
        playerController.transform.position = initialPlayerPosition;

        playerController.healthController.SetHealth();

        playerController.gameObject.SetActive(true);
    }
}