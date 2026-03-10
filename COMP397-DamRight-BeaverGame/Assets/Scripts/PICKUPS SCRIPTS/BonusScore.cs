//Natashya Peddle  301487275

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BonusScore : MonoBehaviour
{
    [SerializeField] private GameObject branch;
    [SerializeField] private TextMeshProUGUI scoreText;

    public static BonusScore Instance;

    public int score;
    public int maxScore = 11;

    private void Start()
    {
        score = 0;

        updateScoreUI();
    }

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        GameObject scoreObject = GameObject.Find("ScoreText");
        //GameObject scoreObjectTagged = GameObject.FindGameObjectWithTag("ScoreUI");

        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            //scoreText = FindObjectOfType<TextMeshProUGUI>();
        }
        else
        {
            scoreText = GameObject.FindFirstObjectByType<TextMeshProUGUI>();
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
            Debug.Log(score);
            scoreText.text = " " + score;
        }
        else
        {
            Debug.LogWarning("ScoreText reference is not assigned");
        }
    }


}
