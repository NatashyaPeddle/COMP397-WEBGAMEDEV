///Code / Internal Documentation - File Name: Item
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Factory Method Pattern
using UnityEngine;

public abstract class Item
{
    protected GameObject prefab;

    public abstract void SetItemPrefab(GameObject prefab);
    public abstract GameObject GetItemPrefab();
}
