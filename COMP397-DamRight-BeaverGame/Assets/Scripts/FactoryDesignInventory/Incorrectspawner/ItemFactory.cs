using UnityEngine;

[CreateAssetMenu(fileName = "New Item Factory", menuName = "ItemFactory/Spawner")]
public abstract class ItemFactory : ScriptableObject
{
    public ItemSO ItemSO;

    public GameObject SpawnItem(Vector3 position, Quaternion rotation)
    {
        if (ItemSO == null)
        {
            Debug.LogError("ItemSO not found");
            return null;
        }

        if (ItemSO.prefab == null)
        {
            Debug.LogError("Prefab not found:" + ItemSO.ItemName);
            return null;
        }

        GameObject spawnedItem = GameObject.Instantiate(ItemSO.prefab, position, rotation);
        spawnedItem.name = ItemSO.ItemName;
        return spawnedItem;

    }
}


