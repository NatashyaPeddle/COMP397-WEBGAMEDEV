//Natashya Peddle  301487275
using UnityEngine;



public class BranchCollectible : MonoBehaviour
{
    [SerializeField] private GameObject branch;
    [SerializeField] private BonusScore bonusScore;

    public int branchNum = 1;

    private void Start()
    {
        bonusScore = FindObjectOfType<BonusScore>();
        if (bonusScore == null)
        {
            Debug.LogWarning("Cant find bonus score");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Branch Picked up");

            if(bonusScore != null)
            {
                bonusScore.branchCollect(branchNum);
            }
            else
            {
                Debug.LogWarning("bonus score reference is not assigned to branch collectible");
            }
                Destroy(gameObject);
        }
    }
}
