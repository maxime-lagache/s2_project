using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public bool restartRequest; // initialisation d'une variable booléenne

    public void Update() //Mise à jour appelé à chaque image
    {
        if (Input.GetButtonDown("Cancel")) //Lorsque l'on appuye sur le bouton "Cancel" ou "R"
        {
            if (!restartRequest) //Si restartRequest est faux
            {
                RestartGame(); //On lance la méthode RestartGame()
                restartRequest = true; //restartRequest est vrai
            }
        }
        else //Lorsque l'on n'appuye pas sur le bouton "Cancel" ou "R"
        {
            restartRequest = false; //restartRequest est faux
        }
    }

    public void RestartGame()
    {
        Debug.Log("On relance."); //Afficher dans la console "On relance."
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Lancer la scène actuelle
    }
}
