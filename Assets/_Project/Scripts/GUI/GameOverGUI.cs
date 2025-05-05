using TMPro;
using UnityEngine;

public class GameOverGUI : GUIBase
{
    [Header("Components")]
    public TextMeshProUGUI text; // Use TextMeshProUGUI for UI text components

    public void GameOver()
    {
        text.text = "Game Over";
        Show(); // Optionally show the Game Over UI
    }
}