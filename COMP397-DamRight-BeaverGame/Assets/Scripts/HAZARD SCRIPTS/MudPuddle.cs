
///Code / Internal Documentation - File Name: MudPuddle
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: When the player steps on the hazard, it causes the player to slide forward/in the direction you were moving, making the mud feel "slippery".

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
