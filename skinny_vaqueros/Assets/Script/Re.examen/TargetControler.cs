using UnityEngine;

public class TargetControler : MonoBehaviour
{
    [SerializeField]
    int recompensa = 0;
    [SerializeField]
    float timeScreen = 5f;
    float timeOnScreen;

    GameControler Controler;

    GameObject escondite;

    public void Activar(GameObject spawn)
    {
        escondite = spawn;
        escondite.SetActive(true);
    }

    void Desactivar(GameObject objeto)
    {
        objeto.gameObject.SetActive(false);
    }


    public void AccionOnTarget()
    {
        gameObject.SetActive(false);
        Controler.AddPoint(recompensa);

        //Desactivar(escondite);
    }

    void Start()
    {
        timeOnScreen = timeScreen;
    }


    // Update is called once per frame
    void Update()
    {
        timeOnScreen -= Time.deltaTime;
        if (timeOnScreen < 0)
        {
            Desactivar(escondite);
            gameObject.SetActive(false);
        }
    }
}
