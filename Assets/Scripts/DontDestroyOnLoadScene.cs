using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;
    //Création d'un tableau d'objets

    void Awake() //Lorsque le script est chargé
    {
        foreach(var element in objects) //Pour chaque élément dans objet
        {
            DontDestroyOnLoad(element); //Ne pas détruire ces éléments lors d'un passage d'une scène à l'autre
        }
    }
}
