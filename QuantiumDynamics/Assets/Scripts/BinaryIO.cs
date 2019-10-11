using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinaryIO : MonoBehaviour
{

    public BoolData boolData;
    public NarrativeManager narrativeManager;
    const string folderName = "BinarySaveData";
    const string fileExtension = ".dat";

    private void Update() {

        if (Input.GetKeyDown(KeyCode.F7)) {

            narrativeManager.CheckBools();

            string folderPath = Application.persistentDataPath + "/" + folderName;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string dataPath = folderPath + '/' + "SaveData" + fileExtension;
            SaveData(boolData, dataPath);

        }

        if (Input.GetKeyDown(KeyCode.F8)) {

            string[] filePaths = GetFilePaths();

            if (File.Exists(Application.persistentDataPath + "/" + folderName + "/" + "SaveData.dat"))
                boolData = LoadData(filePaths[0]);

            narrativeManager.LoadBools();

        }

    }

    static void SaveData(BoolData data, string path) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate)) {

            binaryFormatter.Serialize(fileStream, data);

        }

    }

    static BoolData LoadData(string path) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.Open)) {

            return (BoolData)binaryFormatter.Deserialize(fileStream);

        }

    }

    static string[] GetFilePaths() {

        string folderPath = Application.persistentDataPath + "/" + folderName;

        return Directory.GetFiles(folderPath);

    }

}
