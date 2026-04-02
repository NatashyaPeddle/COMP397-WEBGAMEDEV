///Code / Internal Documentation - File Name: SaveLoadSystem
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Save System

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
{
    public GameData gameData;
    IDataService dataService;

    protected override void Awake()
    {
        base.Awake();
        dataService = new FileDataService(new JsonSerializer());

        if (gameData == null)
        {
            gameData = new GameData();
        }
    }

    public void SaveGame(string saveName)
    {
        gameData.fileName = saveName;
        gameData.sceneName = SceneManager.GetActiveScene().name;
        dataService.Save(gameData);
    }

    public void LoadGame(string gameName)
    {
        gameData = dataService.Load(gameName);

        if (gameData == null)
        {
            return;
        }

        Time.timeScale = 1;
        
        if (string.IsNullOrWhiteSpace(gameData.sceneName))
        {
            gameData.sceneName = "Level 1";
        }

        SceneManager.LoadScene(gameData.sceneName);
}

    public void DeleteGame(string gameName)
    {
        dataService.Delete(gameName);
    }

    public IEnumerable<string> ListAllSaves()
    {
        return dataService.ListSaves();
    }

}
