///Code / Internal Documentation - File Name: GameData
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Save System

using UnityEngine;

[System.Serializable]
public class GameData
{
    public string fileName;
    public string sceneName;
    public SerializableVector3 playerPosition;
    public int playerHealth;
    public int playerAmmo;
    public int branchesCollected;
}

[System.Serializable]
public struct SerializableVector3
{
    public float x, y, z;
    public SerializableVector3(float x, float y, float z) 
    { 
        this.x = x; 
        this.y = y; 
        this.z = z; 
    }
    public SerializableVector3(Vector3 v) 
    { 
        x = v.x; 
        y = v.y; 
        z = v.z; 
    }
    public Vector3 ToVector3() => new Vector3(x, y, z);
}