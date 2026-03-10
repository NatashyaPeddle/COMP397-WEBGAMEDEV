//Natashya Peddle  301487275

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BonusScore : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    public static BonusScore Instance;

    public int score;
    public int maxScore = 11;

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
        GameObject scoreObject = GameObject.Find("ScoreText");
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
    }


}
