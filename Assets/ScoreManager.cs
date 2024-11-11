using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;  // Reference to the left score text
    public TextMeshProUGUI rightScoreText; // Reference to the right score text
    private int leftScore = 0;  // Player 1's score
    private int rightScore = 0; // Player 2's score

    // Call this method when Player 1 scores
    public void Player1Scores()
    {
        leftScore++;
        UpdateScoreDisplay();
    }

    // Call this method when Player 2 scores
    public void Player2Scores()
    {
        rightScore++;
        UpdateScoreDisplay();
    }

    // Update the UI with the current scores
    private void UpdateScoreDisplay()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }
}