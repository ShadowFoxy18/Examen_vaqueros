using UnityEngine;

public class TargetControler : MonoBehaviour
{
    [SerializeField]
    int recompensa = 0;
    [SerializeField]
    float timeOnScreen = 5f;

    GameControler controler;

    GameObject escondite;

    public void Activar(GameObject spawn)
    {
        escondite = spawn;
        escondite.SetActive(true);
    }

    void Desactivar()
    {
        gameObject.SetActive(false);
    }


    public void AccionOnTarget()
    {
        Desactivar();
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
