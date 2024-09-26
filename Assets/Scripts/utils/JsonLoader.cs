using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public static T LoadJsonFile<T>(string Path)
    {
        string jsonText;
        string fullPath = Application.dataPath + Path;
        using (StreamReader reader = File.OpenText(fullPath))
        {
            jsonText = reader.ReadToEnd();
            reader.Close();
        }
        T result = JsonConvert.DeserializeObject<T>(jsonText);
        return result;
    }
}
