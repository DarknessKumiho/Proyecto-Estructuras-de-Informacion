using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronometerController : MonoBehaviour
{
    [Tooltip("Tiempo inicial el segundos")]
    public float initialTime;

    [Tooltip("Escala de tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float timeScale = 1;

    private Text Text_To_Show;

    private float frameTimeWhitTimeScale = 0f;
    private float timeInSecondToShow = 0f;
    private float pauseTimeScale, initialTimeScale;

    public bool isPaused;

    public ScoreBoardController Score;

    void Start()
    {
        //Establecer la escala de tiempo original.
        initialTimeScale = timeScale;

        //Opteniendo el componente Text del reloj.
        Text_To_Show = GetComponent<Text>();

        //Inicializando la variable que acomula el tiempo transcurrido en cada frame.      
        timeInSecondToShow = initialTime;

        //Poniendo en el reloj el tiempo inicial que definimo en la variable publica.
        UpdateWatch(initialTime);

    }

    void Update()
    {

        if (!isPaused)
        {
            //Tiempo de cada frame con base a la escala de tiempo que definimos con rango de (-10, 10)
            frameTimeWhitTimeScale = Time.deltaTime * timeScale;

            //Acomulando el tiempo que será mostrado en el reloj.
            timeInSecondToShow += frameTimeWhitTimeScale;

            UpdateWatch(timeInSecondToShow);
        }
    }

    public void UpdateWatch(float anyTime)
    {
        int minutes = 0;
        int seconds = 0;
        string watchText;

        //Asegurar que el tiempo no sea negativo.
        if (anyTime < 0) anyTime = 0;

        //Calculando minutos y segundos apartir del tiempo acomulado de los frames transcurridos.
        minutes = (int)(anyTime / 60);
        seconds = (int)(anyTime % 60);

        //Creando el string con 2(00) dígitos para los minutos y segundos (separados por ":").
        watchText = minutes.ToString("00") + ":" + seconds.ToString("00");

        //Actualizar el componente text de   UI con el string.
        Text_To_Show.text = watchText;
    }

    public void ResetWatch()
    {
        TimeRecord TimeToSave = new TimeRecord();
        TimeToSave.time = timeInSecondToShow;
        TimeToSave.renderTime = Text_To_Show.text;
        
        SaverLoaderData DataBase = Score.DataBase;
        DataBase.SaveData(TimeToSave, Score.FilePath, Score.FileName);

        isPaused = true;
        timeScale = initialTimeScale;
        timeInSecondToShow = initialTime;
        UpdateWatch(timeInSecondToShow);

        Score.ClearScoreBoard();

        Score.UpdateScores();

    }

}