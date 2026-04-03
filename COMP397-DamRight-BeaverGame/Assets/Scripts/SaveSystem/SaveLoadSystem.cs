///Code / Internal Documentation - File Name: SaveLoadSystem
///Author's Name (s) & Student#: Natashya Peddle #301487275 & Kristopher Prince #301462555
///Program Description / Purpose: Save System

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaveLoadSystem : MonoBehaviour
{
    public static SaveLoadSystem Instance;
    private IDataService dataService;
    public GameData gameData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dataService = new FileDataService(new JsonSerializer());
        if (gameData == null)
            gameData = new GameData();
    }

    public void SaveGame(string saveName)
    {
        gameData.fileName = saveName;

        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            gameData.playerPosition = new SerializableVector3(player.transform.position);

            var health = player.GetComponent<PlayerHealth>();
            if (health != null)
                gameData.playerHealth = health.health;

            var shooter = player.GetComponent<PlayerShooter>();
            if (shooter != null)
                gameData.playerAmmo = shooter.ammo;
        }

        if (BonusScore.Instance != null)
            gameData.branchesCollected = BonusScore.Instance.score;

        gameData.sceneName = SceneManager.GetActiveScene().name;
        dataService.Save(gameData);
    }

    public void LoadGame(string saveName)
    {
        gameData = dataService.Load(saveName);
        if (gameData == null)
            return;

        StartCoroutine(LoadAndApplySave());
    }

    private IEnumerator LoadAndApplySave()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(gameData.sceneName);
        while (!op.isDone)
            yield return null;

        yield return null; // wait one more frame to ensure player prefab is instantiated

        var player = GameObject.FindGameObjectWithTag("Player");
        while (player == null) // wait until player exists
        {
            yield return null;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        player.transform.position = gameData.playerPosition.ToVector3();

        var health = player.GetComponent<PlayerHealth>();
        if (health != null)
            health.health = gameData.playerHealth;

        var shooter = player.GetComponent<PlayerShooter>();
        if (shooter != null)
            shooter.ammo = gameData.playerAmmo;

        if (BonusScore.Instance != null)
        {
            BonusScore.Instance.score = gameData.branchesCollected;
            BonusScore.Instance.updateScoreUI();
        }

        Time.timeScale = 1f;
    }
}