using UnityEngine;

public class SimpleInventory : PersistentSingleton<SimpleInventory>
{
    public int oakSpike = 0;
    public int berry = 0;
}

public class ArrayInventory : PersistentSingleton<SimpleInventory>
{
    public Item[] inventoryItems = new Item[0];
}

[System.Serializable]
public class Item
{
    public bool isStackable = false;
}