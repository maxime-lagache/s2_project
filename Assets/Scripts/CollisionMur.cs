﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionMur : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator player;
    //initialisation de 3 variables de type Transform (pour les déplacements d'objet), et Animator (pour les animations)

    private void Awake() //Lorsque le script est chargé
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; //playerSpawn est associé à l'objet contenant le tag "PlayerSpawn". A une position bien définie 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>(); //player est associé à l'objet contenant le tag "Player". Gère les animations des objets associés
    }

    private void OnTriggerEnter2D(Collider2D collision) //Lorsqu'un autre objet traverse cet objet contenant le script CollisionMur
    {
        if (collision.CompareTag("Player")) //Si l'objet en collision a le tag "Player"
        {
            StartCoroutine(ReplacePlayer(collision)); //Lance la coroutine "ReplacePlayer"
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        player.SetTrigger("Die"); //Lance l'animation "Die" lorsque le joueur traverse l'objet contenant le script CollisionMur
        collision.enabled = false; //Désactive la collision avec tout autre objet du personnage
        yield return new WaitForSeconds(0.48f); //Attendre 0.48s avant de lancer la ligne en dessous
        collision.transform.position = playerSpawn.position; //Repositionne le joueur à l'entré du niveau actuel
        collision.enabled = true; //Réactive la collision avec tout autre objet du personnage
    }
}