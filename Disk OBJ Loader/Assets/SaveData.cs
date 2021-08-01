using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveData
{
    public static void Save(MeshData mesh)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Directory.GetCurrentDirectory() + "/meshData.dta";

        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(mesh);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved Data to " + path);
    }

    public static Data Load()
    {
        string path = Directory.GetCurrentDirectory() + "/meshData.dta";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return null;
        }
    }

}
