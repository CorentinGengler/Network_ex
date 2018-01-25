using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public bool Used = false;
    public Vector3 Position { get { return transform.position; } }
    public Quaternion Rotation { get { return transform.rotation; } }

    public static SpawnPoint GetRandomPoint () {
        SpawnPoint []  spawns =  FindObjectsOfType<SpawnPoint>();
        if (spawns.Length == 0)
            return null;
        return spawns[UnityEngine.Random.Range(0,spawns.Length)];

	}

    internal static void Reposition(Transform affected)
    {
        SpawnPoint point = GetRandomPoint();
        if(point!=null)
            affected.position = point.Position;
    }
}
