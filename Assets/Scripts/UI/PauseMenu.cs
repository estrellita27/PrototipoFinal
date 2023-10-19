using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject playGame;

    public static Estado estado;

    bool escKey;

    void Awake(){
        estado = Estado.play;
        escKey = false;
    }


    public void Update(){

        if(estado == Estado.play){

            if(Input.GetKeyDown(KeyCode.Escape) && !escKey){
                estado = Estado.pause;
                escKey = true;
                pauseMenu.SetActive(true);
                playGame.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            if(!Input.GetKeyDown(KeyCode.Escape)) escKey = false;
        }

         
        if(estado == Estado.pause){

            if(Input.GetKeyDown(KeyCode.Escape) && !escKey)
            {
                estado = Estado.play;
                pauseMenu.SetActive(false);
                playGame.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;  
            }
            if(!Input.GetKeyDown(KeyCode.Escape)) escKey = false;  
        }


    }
    

    public void Continuar(){
        
        estado = Estado.play;
        playGame.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        
    }

    public void MenuPrincipal(){
        
        SceneManager.LoadScene("PantallaSelect");
        
    }

    public void Salir_5(){
        
        Application.Quit();
        
    }

    public enum Estado
    {
        menu,
        play,
        pause,
        gameOver
    }




}