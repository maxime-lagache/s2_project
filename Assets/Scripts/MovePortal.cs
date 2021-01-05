using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class MovePortal : MonoBehaviour
{
    private GameObject player;
    private Vector2 target;
    private Transform orangePortal;
    private Transform bluePortal;
    //initialisation de différentes variables

    void Start() // Start is called before the first frame update
    {
        player = GameObject.FindGameObjectWithTag("Player"); //player est associé à l'objet contenant le tag "Player".
        bluePortal = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>(); //bluePortal est associé à l'objet contenant le tag "BluePortal". A une position variable
        orangePortal = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Transform>(); //orangePortal est associé à l'objet contenant le tag "OrangePortal". A une position variable
    }

    void Update() //Mise à jour appelé à chaque image
    {
        Vector3 origin3D = player.transform.position; //initialise un vecteur 3D pour la position du joueur
        Vector3 direction3D = Camera.main.ScreenToWorldPoint(Input.mousePosition) - origin3D; //initialise un vecteur 3D pour la direction du joueur en fonction de la camera
        direction3D.z = 0; //La valeur en z du vecteur vaut 0
        direction3D = direction3D.normalized; //A une longueur de 1

        Vector2 origin = new Vector2(origin3D.x, origin3D.y); //créé un vecteur pour l'origin
        Vector2 direction = new Vector2(direction3D.x, direction3D.y); //créé un vecteur pour la direction
        int noPlayerMask = ~LayerMask.GetMask("Player"); //ne prend pas en compte la collsison du joueur
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, noPlayerMask); //Créé un impact sur l'élément grâce aux vecteurs créés précédemment sans prendre en compte les collisions du joueur

        if (Input.GetMouseButtonDown(0)) //Si on appuye sur le bouton gauche de la souris
        {
            UnityEngine.Debug.DrawRay(player.transform.position, direction, Color.red, 0.1f, false); //Créé dans la scène (différent de celle du jeu) un vecteur rouge
            if (hit.collider != null) //Si un élément à été touché
            {
                UnityEngine.Debug.Log("clicked"); //Affiche dans la console "clicked"
                if(hit.collider.gameObject.tag != "non compatible") //Si l'élément touché n'a pas le tag "nom compatible"
                { 
                    if (hit.collider.gameObject.tag == "Support") //Si l'élément touché a le tag "Support"
                    {
                        UnityEngine.Debug.Log(hit.collider.gameObject.tag + " ok"); //Affiche dans la console le tag de l'objet touché + "ok"
                        target = hit.point; //Initialise à la variable target l'endroit où il y a eu une collision avec l'élément
                        bluePortal.transform.rotation = hit.collider.transform.rotation; //Retourne le portail pour qu'il suive la rotation de l'élément
                        bluePortal.position = target; //Place sur cet élément (à l'endroit cliqué) le portail bleu
                    }
                }   
            }

        }
        else if (Input.GetMouseButtonDown(1)) //Si on appuye sur le bouton droit de la souris
        {
            UnityEngine.Debug.DrawRay(player.transform.position, direction, Color.red, 0.1f, false); //Créé dans la scène (différent de celle du jeu) un vecteur rouge
            if (hit.collider != null) //Si un élément à été touché
            {
                UnityEngine.Debug.Log("clicked"); //Affiche dans la console "clicked"
                if (hit.collider.gameObject.tag != "non compatible") //Si l'élément touché n'a pas le tag "nom compatible"
                {
                    if (hit.collider.gameObject.tag == "Support") //Si l'élément touché a le tag "Support"
                    {
                        UnityEngine.Debug.Log(hit.collider.gameObject.tag + " ok"); //Affiche dans la console le tag de l'objet touché + "ok"
                        target = hit.point; //Initialise à la variable target l'endroit où il y a eu une collision avec l'élément
                        orangePortal.transform.rotation = hit.collider.transform.rotation; //Retourne le portail pour qu'il suive la rotation de l'élément
                        orangePortal.position = target; //Place sur cet élément (à l'endroit cliqué) le portail orange
                    }
                }
            }
        }
    }
}

