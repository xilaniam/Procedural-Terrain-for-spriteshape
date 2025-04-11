using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ProceduralObjectSpawner : MonoBehaviour
{
    [SerializeField] SpriteShapeController shape;
    [SerializeField] GameObject spawningObject;
    [SerializeField] float offset;
    [SerializeField] int spawningCount;

    int numberOfPoints;
    void Start()
    {
        numberOfPoints = shape.spline.GetPointCount();
        SpawnObject();
    }

    void SpawnObject()
    {
        for (int i = 0; i < spawningCount; i++)
        {
            int randomVal = Random.Range(3, numberOfPoints);
            Vector3 pos = shape.spline.GetPosition(randomVal);
            Vector3 endPos = shape.transform.TransformPoint(pos);
            endPos.y += offset;
            Instantiate(spawningObject, endPos, Quaternion.identity , transform);
        }
    }
}
