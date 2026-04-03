using UnityEngine;
using UnityEditor;

public class CreateSpawnPointsFromBerries
{
    [MenuItem("Tools/Create SpawnPoints From Berries")]
    static void CreateSpawnPoints()
    {
        // Find all berries in the scene
        GameObject[] berries = GameObject.FindGameObjectsWithTag("Berry");

        if (berries.Length == 0)
        {
            Debug.LogWarning("No berries found in the scene!");
            return;
        }

        // Create a parent object to keep things organized
        GameObject parent = GameObject.Find("SpawnPointsParent");
        if (parent == null)
        {
            parent = new GameObject("SpawnPointsParent");
        }

        int count = 0;

        foreach (GameObject berry in berries)
        {
            if (berry == null) continue;

            // Create new spawn point
            GameObject spawnPoint = new GameObject("SpawnPoint");
            spawnPoint.transform.position = berry.transform.position;

            // Parent it (optional but clean)
            spawnPoint.transform.parent = parent.transform;

            count++;

            // Delete the berry
            Object.DestroyImmediate(berry);
        }

        Debug.Log($"Created {count} spawn points and removed all berries.");
    }
}
