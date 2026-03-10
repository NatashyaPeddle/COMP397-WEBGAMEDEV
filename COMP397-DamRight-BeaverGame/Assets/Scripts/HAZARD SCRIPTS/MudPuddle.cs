//Natashya Peddle  301487275
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR;

public class MudPuddle : MonoBehaviour
{

    public float slidespeed = 15f;

    private void OnTriggerStay(Collider other)
    {
       

        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                Vector3 slide = other.transform.forward * slidespeed * Time.deltaTime;
                controller.Move(slide);

                Debug.Log("Sliding");
                
            }
        }
    }
}
