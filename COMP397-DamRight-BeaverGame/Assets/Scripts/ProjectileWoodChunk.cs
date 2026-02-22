using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class ProjectileWoodChunk : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
