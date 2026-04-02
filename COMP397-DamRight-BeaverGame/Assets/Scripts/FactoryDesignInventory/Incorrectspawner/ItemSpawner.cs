using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemSO itemToSpawn;
    public Transform spawnPoint;
    public Vector3 rotationEuler = Vector3.zero;


    public void SpawnItem()
    {
        if (itemToSpawn == null ||itemToSpawn.prefab == null)
        {
            Debug.LogError("Item or prefab not found.");
        }

        GameObject spawnedItem = Instantiate(itemToSpawn.prefab, spawnPoint.position, Quaternion.Euler(rotationEuler));
        spawnedItem.name = itemToSpawn.ItemName;
    }

    private void Start()
    {
        SpawnItem();
    }
}
