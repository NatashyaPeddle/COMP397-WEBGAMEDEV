///Code / Internal Documentation - File Name: Item
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Factory Method Pattern
using UnityEngine;

public class Berry : Item
{
    public override void SetItemPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }
    public override GameObject GetItemPrefab()
    {
        return prefab;
    }
}
