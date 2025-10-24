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
    float timeGame = 60;
    float timeOnGame;
    [SerializeField]
    TextMeshProUGUI textTime;

    float minTimeOnScreen, maxTimeOnScreen = 10f;
    //Tiempo

    //
    int puntos;
    [SerializeField]
    TextMeshProUGUI textPuntos;
    [SerializeField]
    TextMeshProUGUI textFinal;
    // Puntos

    bool playerActive;


    //
    float minTimeScreen = 5f;
    float maxTimeScreen = 10f;
    // Randomizador aparicion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerActive = false;

        startScreen.SetActive(true);
        endScreen.SetActive(false);
    }


    public void StartButton()
    {
        //tiempos y puntos
        puntos = 0;
        timeOnGame = timeGame;

        startScreen.SetActive(false);
        playerActive = true;
    }

    public void EndButton()
    {
        startScreen.SetActive(true);
        endScreen.SetActive(false);
    }


    void AddPoint(int value)
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
                TimeGame();
                ActivarTarget();
            }
        }
    }


    void TimeGame()
    {
        textTime.text = puntos.ToString("00");
    }


    void ActivarTarget()
    {

    }
}
