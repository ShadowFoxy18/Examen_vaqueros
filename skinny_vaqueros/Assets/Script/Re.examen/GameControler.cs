using TMPro;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    //
    [SerializeField]
    GameObject startScreen;
    [SerializeField]
    GameObject endScreen;
    //Screen

    //
    [SerializeField]
    GameObject[] targets;
    //Targets


    //
    [SerializeField]
    GameObject[] targetsPosition;
    //Positions

    //
    public float timeGame = 60;
    float timeOnGame;
    [SerializeField]
    TextMeshProUGUI textTime;

        //
    public float minTimeToActive, maxTimeToActive = 10f;
        // Randomizador aparicion
    float timeToActive;
    //Tiempo

    //
    int puntos;
    [SerializeField]
    TextMeshProUGUI textPuntos;
    [SerializeField]
    TextMeshProUGUI textFinal;
    // Puntos

    bool playerActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeGame();
        PointGame();
        playerActive = false;

        startScreen.SetActive(true);
        endScreen.SetActive(false);


        DesactivarTargets(targets);
        DesactivarTargets(targetsPosition);
    }


    public void StartButton()
    {
        //tiempos y puntos
        puntos = 0;
        timeOnGame = timeGame;

        startScreen.SetActive(false);
        playerActive = true;

        timeToActive = RandomTimeToActive();
    }

    public void EndButton()
    {

        startScreen.SetActive(true);
        endScreen.SetActive(false);

        DesactivarTargets(targets);
        DesactivarTargets(targetsPosition);
    }


    public void AddPoint(int value)
    {
        puntos += value;
        textPuntos.text = value.ToString() + " s";
    }


    // Update is called once per frame
    void Update()
    {
        if (playerActive)
        {

            if (timeOnGame < 0)
            {
                timeOnGame = 0;
                TimeGame();

                textFinal.text = puntos.ToString() + " s";
                playerActive = false;
                endScreen.SetActive(true);
            }
            else
            {
                timeOnGame -= 1 * Time.deltaTime;
                timeToActive -= Time.deltaTime;
                TimeGame();
                PointGame();
                if (timeToActive < 0)
                {
                    ActivarTarget();
                    timeToActive = RandomTimeToActive();
                }
                
            }
        }
    }

    void PointGame()
    {
        textPuntos.text = puntos.ToString() + " s";
    }

    void TimeGame()
    {
        textTime.text = timeOnGame.ToString("00");
    }

    float RandomTimeToActive()
    {
        return Random.Range(minTimeToActive, maxTimeToActive);
    }

    int RandomNumber(int value)
    {
        return Random.Range(0, value);
    }


    void ActivarTarget()
    {
        GameObject target = RandomGameObject(targets);
        GameObject position = RandomGameObject(targetsPosition);

        target.transform.position = position.GetComponentInParent<Transform>().position;

        target.SetActive(true);
    }


    void DesactivarTargets(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }

    GameObject RandomGameObject(GameObject[] gameObjects)
    {
        GameObject objeto = gameObjects[RandomNumber(gameObjects.Length)];
        
        while (gameObjects[RandomNumber(gameObjects.Length)].activeSelf)
        {
            objeto = gameObjects[RandomNumber(gameObjects.Length)];
        }
        return objeto;
    }
}
