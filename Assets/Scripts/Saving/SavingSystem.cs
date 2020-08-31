using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace RPG.Saving
{
public class SavingSystem : MonoBehaviour 
{
 public void Save(string saveFile)
 {
     string path = GetPathFromSaveFile(saveFile);
     print ("Saving to " + path);
     using (FileStream stream = File.Open(path, FileMode.Create))
     {
        Transform playerTransform =  GetPlayerTransform();
        BinaryFormatter formatter = new BinaryFormatter();
        SerializeableVector3 position = new SerializeableVector3(playerTransform.position);
        formatter.Serialize(stream, position);

     }
 }

  public void Load(string saveFile)
 {
     string path = GetPathFromSaveFile(saveFile);
     print ("Loading from " + GetPathFromSaveFile(saveFile));
     using (FileStream stream = File.Open(path, FileMode.Open))
     {
         byte[] buffer = new byte[stream.Length];
         stream.Read(buffer, 0, buffer.Length);

        Transform playerTransform =  GetPlayerTransform();
        BinaryFormatter formatter = new BinaryFormatter();
        SerializeableVector3 position = (SerializableVector3)formatter.Deserialize(stream);
        playerTransform.position = position.ToVector();
     
     }
  }

  private Transform GetPlayerTransform()
  {
      return GameObject.FindWithTag("Player").transform;
  }
private byte[] SerializeVector(Vector3 vector)
{
 byte [] vectorBytes = new byte[3 * 4];
 BitConverter.GetBytes(vector.x).CopyTo(vectorBytes, 0);
 BitConverter.GetBytes(vector.y).CopyTo(vectorBytes, 4);
 BitConverter.GetBytes(vector.z).CopyTo(vectorBytes, 8);
 return vectorBytes;

}

private  Vector3 DeserializeVector(byte[] buffer)
{  
 Vector3 result = new Vector3();
 result.x = BitConverter.ToSingle(buffer, 0);
 result.y = BitConverter.ToSingle(buffer, 4);
 result.z = BitConverter.ToSingle(buffer, 8);
 return result;
}

 private string GetPathFromSaveFile(string saveFile)
 {
     return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
 }
}
}