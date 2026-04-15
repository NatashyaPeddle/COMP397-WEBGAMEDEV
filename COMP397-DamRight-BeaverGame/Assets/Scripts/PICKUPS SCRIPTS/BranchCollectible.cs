///Code / Internal Documentation - File Name: BranchCollectible
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Allows the player to pick up branches and adds to bonus branch score.


using UnityEngine;



public class BranchCollectible : MonoBehaviour
{
    [SerializeField] private GameObject branch;
    [SerializeField] private BonusScore bonusScore;

    

    public int branchNum = 1;

    private void Start()
    {
        bonusScore = FindFirstObjectByType<BonusScore>();
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
            EventChannelManager.Instance.stickEvent.RaiseEvent();

            if(BonusScore.Instance != null)
            {
                BonusScore.Instance.branchCollect(branchNum);
            }
            else
            {
                Debug.LogWarning("bonus score reference is not assigned to branch collectible");
            }
                Destroy(gameObject);
        }
    }
}
