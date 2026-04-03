///Code / Internal Documentation - File Name: Item
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Factory Method Pattern
using UnityEngine;

public class ItemManager: MonoBehaviour
{
    [SerializeField] public ItemsFactory itemsFactory;
    [SerializeField] public Transform[] spawnPoints;

    void SpawnItem(string  itemType, int spawnIndex)
    {

        if(spawnIndex < 0 || spawnIndex >= spawnPoints.Length)
        {
            Debug.LogError("Index out of bounds");
            return;
        }


        Item item = itemsFactory.CreateItem(itemType);

        if (item != null)
        {
            GameObject spawned = Instantiate(item.GetItemPrefab(), spawnPoints[spawnIndex].position, Quaternion.identity);
            spawned.name = itemType;
        }
    }

    private void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnItem("Berry", i);
        }
    }


}