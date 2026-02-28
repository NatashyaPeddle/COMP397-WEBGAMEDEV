//Natashya Peddle  301487275
//Kristopher Prince #301462555

using UnityEngine;

public class ProjectileWoodChunk : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPCBody"))
        {
            NPC npc = other.GetComponentInParent<NPC>();
            if (npc != null)
            {
                npc.Damage(1);
                Destroy(gameObject);
            }
        }
    }
}
