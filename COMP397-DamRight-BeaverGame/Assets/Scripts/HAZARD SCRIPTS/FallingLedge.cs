//Natashya Peddle  301487275
using System.Collections;
using System.Threading;
using UnityEngine;

public class FallingLedge : MonoBehaviour
{
    public float fallWaitTimer = 0.05f;
    public float fallSpeed = 3f;
    public float fallTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(islandFall());

        }

           

    }


   private IEnumerator islandFall()
    {
        //yield return new WaitForSeconds(fallWaitTimer);

        float frameTimer = 0f;

        while (frameTimer < fallTime)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            frameTimer += Time.deltaTime;

            yield return null;

            Debug.Log("Falling");
        }

        

        Destroy(gameObject);

    }

}
