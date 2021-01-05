using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Diagnostics;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
    //initialisation de 2 variables de type string et Animator (pour les animations)

    private void Awake() //Lorsque le script est chargé
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>(); //fadeSystem est associé à l'objet contenant le tag "PlayerSpawn". Gère les animations des objets associés
    }

    private void OnTriggerEnter2D(Collider2D collision) //Lorsqu'un autre objet traverse cet objet contenant le script LoadSpecificScene
    {
        if(collision.CompareTag("Player")) //Si l'objet en collision a le tag "Player"
        {
            StartCoroutine(loadNextScene()); //Lance la coroutine "ReplacePlayer"
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn"); //Lance l'animation "FadeIn" lorsque le joueur traverse l'objet contenant le script LoadSpecificScene
        yield return new WaitForSeconds(1f); //Attendre 1s avant de lancer la ligne en dessous
        SceneManager.LoadScene(sceneName); //Lance le nom de la scène spécifié à l'élément contenant ce script (Fait en sorte pour passer au niveau suivant)
    }
}