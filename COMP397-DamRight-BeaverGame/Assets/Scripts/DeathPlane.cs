using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] private float death = 4.5f;
    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth != null && playerHealth.gameObject.transform.position.y <= death)
        {
            playerHealth.Damage(999);
        }
    }
}
