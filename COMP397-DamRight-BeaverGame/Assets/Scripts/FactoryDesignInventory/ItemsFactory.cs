///Code / Internal Documentation - File Name: Item
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Factory Method Pattern
using UnityEngine;

public class ItemsFactory : MonoBehaviour
{
    public GameObject A_BERRY;
    public GameObject SUPER_BERRY;

    public Item CreateItem(string itemType)
    {
        Item item = null;

        if(itemType == "Berry")
        {
            item = new Berry();
            item.SetItemPrefab(A_BERRY);
            return item;

        }
        else if(itemType == "SuperBerry")
        {
            Debug.Log("Berry not implemented");
            return null;

        }
        else
        {
            Debug.Log("Unknown Item");
            return null;
        }
       
    }
}
