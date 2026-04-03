///Code / Internal Documentation - File Name: Item
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Factory Method Pattern
using UnityEngine;

public abstract class Item
{
    protected GameObject prefab;

    public void SetItemPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }
    public GameObject GetItemPrefab()
    {
        return prefab;
    }
}
