using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardController : MonoBehaviour
{

    //Se usan en Awake
    public string FilePath;
    public string FileName;

    public SaverLoaderData DataBase;
    public List<TimeRecord> RecordList;

    //Se usan para llenar los records
    public int iterator = 1;

    public Text
        Posicion1,
        Posicion2,
        Posicion3,
        Posicion4,
        Posicion5,
        Posicion6,
        Posicion7,
        Posicion8,
        Posicion9;

    public Text
        Tiempo1,
        Tiempo2,
        Tiempo3,
        Tiempo4,
        Tiempo5,
        Tiempo6,
        Tiempo7,
        Tiempo8,
        Tiempo9;

    private void Awake()
    {
        DataBase = new SaverLoaderData();
        DataBase.LoadData(FilePath, FileName);

        UpdateScores();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScores()
    {
        RecordList = SaverLoaderData.RecordsData;

        foreach (TimeRecord Record in RecordList)
        {
            RenderRecordEntry(Record);
            iterator++;
        }

        iterator = 1;
    }

    public void ClearScoreBoard()
    {
        Posicion1.text = "";
        Posicion2.text = "";
        Posicion3.text = "";
        Posicion4.text = "";
        Posicion5.text = "";
        Posicion6.text = "";
        Posicion7.text = "";
        Posicion8.text = "";
        Posicion9.text = "";

        Tiempo1.text = "";
        Tiempo2.text = "";
        Tiempo3.text = "";
        Tiempo4.text = "";
        Tiempo5.text = "";
        Tiempo6.text = "";
        Tiempo7.text = "";
        Tiempo8.text = "";
        Tiempo9.text = "";
    }

    public void RenderRecordEntry(TimeRecord Record)
    {
        switch (iterator)
        {
            case 1:
                Posicion1.text = "1er";
                Tiempo1.text = Record.renderTime;
                break;
            case 2:
                Posicion2.text = "2do";
                Tiempo2.text = Record.renderTime;
                break;
            case 3:
                Posicion3.text = "3er";
                Tiempo3.text = Record.renderTime;
                break;
            case 4:
                Posicion4.text = "4";
                Tiempo4.text = Record.renderTime;
                break;
            case 5:
                Posicion5.text = "5";
                Tiempo5.text = Record.renderTime;
                break;
            case 6:
                Posicion6.text = "6";
                Tiempo6.text = Record.renderTime;
                break;
            case 7:
                Posicion7.text = "7";
                Tiempo7.text = Record.renderTime;
                break;
            case 8:
                Posicion8.text = "8";
                Tiempo8.text = Record.renderTime;
                break;
            case 9:
                Posicion9.text = "9";
                Tiempo9.text = Record.renderTime;
                break;

            default: break;
        }
    }
}
