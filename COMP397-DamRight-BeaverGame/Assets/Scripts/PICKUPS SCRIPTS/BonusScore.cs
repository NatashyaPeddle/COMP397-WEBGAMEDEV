
///Code / Internal Documentation - File Name: BonusScore
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Collects the branch score into a number. Turns the branchscore into text.

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BonusScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    public static BonusScore Instance;

    public int score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "LevelOne")
        {
            score = 0;
        }
        
        scoreText = null;
        GameObject scoreObject = GameObject.FindWithTag("ScoreUI");
        //GameObject scoreObjectTagged = GameObject.FindGameObjectWithTag("ScoreUI");

        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            //scoreText = FindObjectOfType<TextMeshProUGUI>();
        }
        else
        {
            scoreText = null;
        }



        updateScoreUI();
    }


    public void branchCollect(int amount)
    {
        score += amount;

        updateScoreUI();
    }

    public void updateScoreUI()
    {
        if (scoreText == null)
        {
            GameObject scoreObject = GameObject.FindWithTag("ScoreUI");

            if (scoreObject != null)
            {
                scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            }
        }

        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
    }


}
