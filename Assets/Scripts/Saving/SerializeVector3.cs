using UnityEngine;

namespace RPG.Saving
{
    [System.Serializable]
     public class SerializeableVector3

     {
        float x, y, z;

        public SerializeableVector3(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
     }
}