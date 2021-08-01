using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public float[] pointsX = new float[8];
    public float[] pointsY = new float[8];
    public float[] pointsZ = new float[8];

    public Data (MeshData data)
    {
        pointsX = data.meshPointsX;
        pointsY = data.meshPointsY;
        pointsZ = data.meshPointsZ;
    }
}
