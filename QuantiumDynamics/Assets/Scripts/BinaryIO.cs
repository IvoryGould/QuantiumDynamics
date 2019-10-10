using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinaryIO : MonoBehaviour
{

    public NarrativeManager narrativeManager;
    const string folderName = "BinarySaveData";
    const string fileExtension = ".dat";

    private void Update() {

        if (Input.GetKeyDown(KeyCode.F7)) {

            string folderPath = Path.Combine(Application.persistentDataPath, folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string dataPath = Path.Combine(folderPath, "SaveData" + fileExtension);
            SaveData(narrativeManager, dataPath);

        }

        if (Input.GetKeyDown(KeyCode.F8)) {

            string[] filePaths = GetFilePaths();

            if (filePaths.Length > 0)
                narrativeManager = LoadData(filePaths[0]);

        }

    }

    static void SaveData(NarrativeManager data, string path) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate)) {

            binaryFormatter.Serialize(fileStream, data);

        }

    }

    static NarrativeManager LoadData(string path) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.Open)) {

            return (NarrativeManager)binaryFormatter.Deserialize(fileStream);

        }

    }

    static string[] GetFilePaths() {

        string folderPath = Path.Combine(Application.persistentDataPath, folderName);

        return Directory.GetFiles(folderPath, fileExtension);

    }

}
