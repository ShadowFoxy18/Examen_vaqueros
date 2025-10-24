using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Blanco : MonoBehaviour
{
    [SerializeField]
    public int valueObject;

    public float timeObject;

     
    public void Disparo()
    {
        Debug.Log("Disparo");
        Debug.Log("Puntos: " + valueObject);

        gameObject.SetActive(false);
    }
}
