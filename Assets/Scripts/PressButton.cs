using System.Diagnostics;
using System.Runtime.Versioning;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    public GameObject wallBlue;
    public GameObject wallRed;
    public GameObject wallGreen;
    //initialisation de 3 variables de type objet

    private void Start() //Lorsque le script se lance
    {     
        wallRed = GameObject.Find("mur_rouge"); //La variable "wallRed" est associé à l'objet ayant comme nom "mur_rouge"
        wallBlue = GameObject.Find("mur_bleu"); //La variable "wallBlue" est associé à l'objet ayant comme nom "mur_bleu"
        wallGreen = GameObject.Find("mur_vert"); //La variable "wallGreen" est associé à l'objet ayant comme nom "mur_vert"
    }

    private void OnTriggerEnter2D(Collider2D collision) //Lorsqu'un autre objet traverse cet objet contenant le script PressButton
    {
        UnityEngine.Debug.Log("appuyé."); //Afficher dans la console "appuyé."
        if (collision.CompareTag("Player") || collision.CompareTag("Cube")) //Si cet autre objet a comme tag "Player" ou "Cube"
        {
            if (gameObject.tag == "BoutonRouge") //Si cet objet contenant le script a comme tag "BoutonRouge"
            {
                UnityEngine.Debug.Log("Ca marche"); //Afficher dans la console "Ca marche"
                wallRed.SetActive(false); // wallRed (étant associé à l'objet ayant comme nom "mur_rouge") est désactivée, c'est-à-dire qu'elle a disparu de la scène
            }

            else if (gameObject.tag == "BoutonBleu") //Si cet objet contenant le script a comme tag "BoutonBleu"
            {
                UnityEngine.Debug.Log("Ca marche"); //Afficher dans la console "Ca marche"
                wallBlue.SetActive(false); // wallBlue (étant associé à l'objet ayant comme nom "mur_bleu") est désactivée
            }
            
            else if (gameObject.tag == "BoutonVert") //Si cet objet contenant le script a comme tag "BoutonVert"
            {
                UnityEngine.Debug.Log("Ca marche"); //Afficher dans la console "Ca marche"
                wallGreen.SetActive(false); // wallGreen (étant associé à l'objet ayant comme nom "mur_vert") est désactivée
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Lorsqu'un autre objet quitte cet objet contenant le script PressButton
    {
        UnityEngine.Debug.Log("appuyé."); //Afficher dans la console "appuyé."
        if (collision.CompareTag("Player") || collision.CompareTag("Cube")) //Si cet autre objet a comme tag "Player" ou "Cube"
        {
            UnityEngine.Debug.Log("appuyé."); //Afficher dans la console "appuyé."
            if (gameObject.tag == "BoutonRouge") //Si cet objet contenant le script a comme tag "BoutonRouge"
            {
                UnityEngine.Debug.Log("Ca marche"); //Afficher dans la console "Ca marche"
                wallRed.SetActive(true); // wallRed (étant associé à l'objet ayant comme nom "mur_rouge") est activée, c'est-à-dire qu'elle réapparaît dans la scène
            }

            else if (gameObject.tag == "BoutonBleu") //Si cet objet contenant le script a comme tag "BoutonBleu"
            {
                UnityEngine.Debug.Log("Ca marche"); //Afficher dans la console "Ca marche"
                wallBlue.SetActive(true); // wallBlue (étant associé à l'objet ayant comme nom "mur_bleu") est activée
            }

            else if (gameObject.tag == "BoutonVert") //Si cet objet contenant le script a comme tag "BoutonVert"
            {
                UnityEngine.Debug.Log("Ca marche"); //Afficher dans la console "Ca marche"
                wallGreen.SetActive(true); // wallGreen (étant associé à l'objet ayant comme nom "mur_vert") est activée
            }
        }
    }
}
