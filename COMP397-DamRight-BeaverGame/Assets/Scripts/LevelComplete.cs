//Natashya Peddle  301487275

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelComplete");
            Debug.Log("Game Completed");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            //InputSystem.actions.FindActionMap("Player").Disable();

            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }


        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("playing");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;


            //InputSystem.actions.FindActionMap("Player").Disable();

            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }
    }
    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    InputSystem.actions.FindActionMap("Player").Enable();
    //    Time.timeScale = 1f;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}


   
}
