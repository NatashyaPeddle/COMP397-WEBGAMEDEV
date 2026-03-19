///Code / Internal Documentation - File Name: JsonSerializer
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Save System

using UnityEngine;

public class JsonSerializer : ISerializer
{

    string ISerializer.Serialize<T>(T obj)
    {
        return JsonUtility.ToJson(obj, true);
    }


    public T Deserialize<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
}
