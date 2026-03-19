//Natashya Peddle  301487275

///Code / Internal Documentation - File Name: MiniMapController
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Controls the minimap 

using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private Transform player;



    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
