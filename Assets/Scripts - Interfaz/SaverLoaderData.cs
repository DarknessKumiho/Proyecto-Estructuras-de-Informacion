using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class SaverLoaderData
{

    public static List<TimeRecord> RecordsData = new List<TimeRecord>();

    public void LoadData(string filePath, string fileName)
    {

        string fullPath = Application.dataPath + "/" + filePath + "/" + fileName;

        Debug.Log(fullPath);
        
        if (File.Exists(fullPath))
        {
            string textJson = File.ReadAllText(fullPath);
            Debug.Log("Data load sucefully.");

            RecordsData = JsonConvert.DeserializeObject<List<TimeRecord>>(textJson);

            for (int i = 0; i < RecordsData.Count; i++)
            {
                for (int j = i + 1; j < RecordsData.Count; j++)
                {
                    if (RecordsData[j].time < RecordsData[i].time)
                    {
                        //swap
                        TimeRecord temp = RecordsData[i];
                        RecordsData[i] = RecordsData[j];
                        RecordsData[j] = temp;
                    }
                }
            }

        }
        else
        {
            Debug.Log("File no found");
        }

    }

    public void SaveData(TimeRecord newData, string filePath, string fileName)
    {

        string fullPath = Application.dataPath + "/" + filePath + "/" + fileName;
        
        if (!File.Exists(fullPath))
        {
            File.Create(fullPath);
        }

        string json = File.ReadAllText(fullPath);
        List<TimeRecord> newDataList = JsonConvert.DeserializeObject<List<TimeRecord>>(json);
        newDataList.Add(newData);

        string dataToAdd = JsonConvert.SerializeObject(newDataList);
        File.WriteAllText(fullPath, dataToAdd);

        string textJson = File.ReadAllText(fullPath);
        Debug.Log("File updated");

        RecordsData = newDataList;

        for (int i = 0; i < RecordsData.Count; i++)
        {
            for (int j = i + 1; j < RecordsData.Count; j++)
            {
                if (RecordsData[j].time < RecordsData[i].time)
                {
                    //swap
                    TimeRecord temp = RecordsData[i];
                    RecordsData[i] = RecordsData[j];
                    RecordsData[j] = temp;
                }
            }
        }

    }

    internal static void SaveData()
    {
        throw new NotImplementedException();
    }
}
