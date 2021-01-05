using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        //Pour passer au prochain niveau.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        //Pour être sur que le jeu se ferme bien en ayant un message dans le terminale.
        Debug.Log("On quitte bien le jeu.");
        //Pour fermer le jeu.
        Application.Quit();
    }
}
