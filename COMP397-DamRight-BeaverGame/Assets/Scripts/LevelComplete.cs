///Code / Internal Documentation - File Name: LevelComplete
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Creates level complete screen with functioning buttons and a branch score. Stops the player from moving / game from playing. 



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
