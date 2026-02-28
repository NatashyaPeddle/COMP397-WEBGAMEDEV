//Natashya Peddle  301487275
using UnityEngine;

public class BranchCollectible : MonoBehaviour
{
    public int branchNum = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Branch Picked up");

        ///COLLECTIBLE SCORE ADDED IN FUTURE UPDATES

        Destroy(gameObject);
    }
}
