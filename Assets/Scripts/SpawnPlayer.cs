using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private void Awake() //Lorsque le script est chargé
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position; //Déplacer l'objet ayant le tag "Player" à la position de l'objet contenant ce script
    }
}
