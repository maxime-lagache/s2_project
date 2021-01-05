using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination; 
    public bool isOrange;
    public float distance = 0.5f; //distance vaut 0.5
    //initialisation de 3 variables de type Transform (pour les déplacements d'objet), booléenne et float

    void Start() //Lorsque le script se lance
    {
        if (!isOrange) //Si la variable "isOrange" est faux
        {
            destination = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Transform>(); //La variable destination est maintenant rattaché à l'objet contenant le tag "OrangePortal" dont sa position peut être changée dans la scène
        }
        else //Si la variable "isOrange" est vraie
        {
            destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>(); //La variable destination est maintenant rattaché à l'objet contenant le tag "BluePortal" dont sa position peut être changée dans la scène
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Lorsqu'un autre objet traverse cet objet (contenant le script Portal)
    {
        if(Vector2.Distance(transform.position, other.transform.position) > distance && (other.gameObject.tag == "Player" || other.gameObject.tag == "Cube")) //Si la distance entre le portail et l'objet en contact est supérieure à 0.5 et que cet objet a comme tag "Cube" ou "Player"
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y); //fait passer le "Player" ou "Cube" par l'un portail et ressort dans l'autre
        }
        
    }
}
