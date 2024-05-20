
using UnityEngine;

namespace GardensBattle.Runtime.Extensions.Unity
{
    public static class Vector3Extensions
    {
        public static Vector3 SetZ(this Vector3 vector, float z) => 
            new(vector.x, vector.y, z);
    }
}