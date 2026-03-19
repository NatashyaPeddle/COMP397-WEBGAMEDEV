//Natashya Peddle  301487275
//Kristopher Prince 30146255
using System.Collections;
using UnityEngine;

public class FallingLedge : MonoBehaviour
{
    public float fallWaitTimer = 2f;
    public float fallSpeed = 0.5f;
    public float fallTime = 1f;
    public float respawnTime = 3f;

    private bool isFalling = false;
    private Vector3 startPosition;
    private Renderer render;
    private Collider[] colliders;

    private Rigidbody rb;

    private void Awake()
    {
        startPosition = transform.position;
        render = GetComponent<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            StartCoroutine(islandFall());
        }
    }

   private IEnumerator islandFall()
    {
        yield return new WaitForSeconds(fallWaitTimer);
        
        float frameTimer = 0f;

        while (frameTimer < fallTime)
        {
            Vector3 newPosition = rb.position + Vector3.down * fallSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            frameTimer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        
        foreach(var col in colliders)
        {
            col.enabled = false;
        }

        render.enabled = false;

        yield return new WaitForSeconds(respawnTime);
        
        rb.position = startPosition;

        foreach(var col in colliders)
        {
            col.enabled = true;
        }

        render.enabled = true;

        isFalling = false;

    }

}