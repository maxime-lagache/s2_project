using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;
    //initialisation de 2 variables de type Transform (pour les déplacements d'objet), et Animator (pour les animations)

    private void Awake() //Lorsque le script est chargé
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; //playerSpawn est associé à l'objet contenant le tag "PlayerSpawn". A une position bien définie 
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>(); //fadeSystem est associé à l'objet contenant le tag "PlayerSpawn". Gère les animations des objets associés
    }

    private void OnTriggerEnter2D(Collider2D collision) //Lorsqu'un autre objet traverse cet objet contenant le script DeathZone
    {
        if (collision.CompareTag("Player")) //Si l'objet en collision a le tag "Player"
        {
            StartCoroutine(ReplacePlayer(collision)); //Lance la coroutine "ReplacePlayer"
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeInDeath"); //Lance l'animation "FadeInDeath" lorsque le joueur traverse l'objet contenant le script DeathZone
        yield return new WaitForSeconds(0.57f); //Attendre 0.57s avant de lancer la ligne en dessous
        collision.transform.position = playerSpawn.position; //Repositionne le joueur à l'entré du niveau actuel
    }
}
