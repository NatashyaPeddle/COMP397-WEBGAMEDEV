//Natashya Peddle  301487275

using UnityEngine;
using TMPro;

public class BonusScore : MonoBehaviour
{
    [SerializeField] private GameObject branch;
    [SerializeField] private TextMeshProUGUI scoreText;

    public int score;
    public int maxScore = 11;

    private void Start()
    {
        score = 0;

        updateScoreUI();
    }

    public void branchCollect(int amount)
    {
        if (score < maxScore)
        {
            score += amount;
        }

        updateScoreUI();
    }

    private void updateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText reference is not assigned");
        }
    }


}
