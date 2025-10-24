using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    //
    [SerializeField]
    GameObject pantallaInicio;
    [SerializeField]
    GameObject pantallaFinal;
    // pantallas de inicio y final


    //
    [SerializeField]
    GameObject[] prefabs;

    [SerializeField]
    int[] valueTarget;
    [SerializeField]
    float[] timeTarget;
    // target de la escena
    public GameObject[] targetsOnScene;
    // targets, valores y tiempos
    bool[] targetsScene;


    //
    [SerializeField]
    Transform[] position;
    // posiciones targets

    //
    [SerializeField]
    TextMeshProUGUI textoTiempo;
    public float tiempoJuego = 60f;
    float time;
    // tiempo del juego

    //
    [SerializeField]
    TextMeshProUGUI textoPuntosFinal;
    [SerializeField]
    TextMeshProUGUI textoValue;
    [SerializeField]
    int puntos = 0;
    // puntos juego

    public float delay = 1.5f;
    float delayScene;

    //
    float[] tiempoObjetos;
    // tiempo target

    bool activo = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetsScene = new bool[targetsOnScene.Length];
        tiempoObjetos = new float[targetsOnScene.Length];

        pantallaFinal.SetActive(false);
        pantallaInicio.SetActive(true);
        valueTarget = new int[prefabs.Length];
        timeTarget = new float[prefabs.Length];

        time = tiempoJuego;
        delayScene = delay;

        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject target = prefabs[i];

            target.SetActive(false);
            valueTarget[i] = target.GetComponent<Blanco>().valueObject;
            timeTarget[i] = target.GetComponent<Blanco>().timeObject;
        }

        for (int i = 0;i < position.Length; i++)
        {
            position[i].gameObject.SetActive(false);
            targetsScene[i] = false;
        }
    }


    //inicia el juego
    public void InitButton()
    {
        pantallaInicio.SetActive(false);
        Debug.Log("Iniciado");
    }

    //boton retry
    public void EndButton()
    {
        Debug.Log("terminado");
    }

    //update texto tiempo
    void TiempoTranscurrido()
    {
        time -= 1 * Time.deltaTime;
        textoTiempo.text = time.ToString("00");
    }

    
    void SacarObjetivos()
    {
        int randomPosition = Random.Range(0, position.Length);
        while (ConfirmarPosicion(randomPosition))
        {
            randomPosition = Random.Range(0, position.Length);
        }
        int randomTarget = Random.Range(0, targetsOnScene.Length);
        while (ConfirmarTarget(randomTarget))
        {
            randomTarget = Random.Range(0, targetsOnScene.Length);
        }

        targetsScene[randomTarget] = true;

        GameObject target = targetsOnScene[randomTarget];
        target.gameObject.SetActive(true);
        position[randomPosition].gameObject.SetActive(true);
        target.transform.position = position[randomPosition].position;
        
        float targetTime = target.GetComponent<Blanco>().timeObject;

        tiempoObjetos[randomTarget] = targetTime;


        delayScene = delay;
    }

    bool ConfirmarPosicion(int referencia)
    {
        if (position[referencia].gameObject.activeSelf)
        {
            return true;
        }
        return false;
    }

    bool ConfirmarTarget(int referencia)
    {
        
        if (targetsOnScene[referencia].gameObject.activeSelf)
        {
            return true;
        }
        return false;
    }

    void TiempoTarget()
    {
        if (activo)
        {
            for (int i = 0; i < tiempoObjetos.Length; i++)
            {
                Debug.Log(tiempoObjetos[i]);
                tiempoObjetos[i] -= 1 * Time.deltaTime;
                if (tiempoObjetos[i] < 0)
                {
                    targetsOnScene[i].gameObject.SetActive(false);
                    targetsScene[i] = false;
                }
            }
        }
        
    }



    // Update is called once per frame
    void Update()
    {

        //juego terminado
        if (time < 0)
        {
            pantallaFinal.SetActive(true);
            textoPuntosFinal.text = puntos.ToString() + " s";
            textoTiempo.text = "0 s";
        }

        for (int i = 0; i < targetsScene.Length; i++)
        {
            
            //revisar si ha sido desactivado un objeto en escena
            if (targetsScene[i] == true && targetsOnScene[i].gameObject.activeSelf == false)
            {
                puntos += targetsOnScene[i].gameObject.GetComponent<Blanco>().valueObject;
                targetsScene[i] = false;
                
            }
            for (int j = 0; j < position.Length; j++)
            { //devolver la imagen sin target a false
                if (targetsOnScene[i].gameObject.transform.position == position[j].position)
                {
                    position[j].gameObject.SetActive(false);
                }
            }
        }


        //juego iniciado con tiempo
        if (pantallaInicio.activeSelf == false && pantallaFinal.activeSelf == false)
        {
            //delay de accion
            delayScene -= 1 * Time.deltaTime;

            //inicia el juego
            TiempoTranscurrido();
            textoValue.text = puntos.ToString() + " s";

            if (delayScene < 0)
            {
                SacarObjetivos();
            }     
        }
    }
}
