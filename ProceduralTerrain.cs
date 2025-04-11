using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ProceduralTerrain : MonoBehaviour
{
    [SerializeField] SpriteShapeController shape;
    [SerializeField] GameObject endpoint;
    [SerializeField] float endPointOffset;
    [SerializeField] float width = 1000;
    [SerializeField] int numberOfPoints = 150;
    [Header("noise")]
    [Range(1,100)]
    [SerializeField] float amplitude = 20;
    [Range(1, 50)]
    [Tooltip("greater the smoother")]
    [SerializeField] float frequency = 12;
    [SerializeField] int seed;

    float randomOffset;
    Vector3 endPos;
    void Start()
    {
        if (!PlayerPrefs.HasKey("seed"))
        {
            seed = 1;
            PlayerPrefs.SetInt("seed", 1);
            PlayerPrefs.Save();
        }
        else
        {
            seed = PlayerPrefs.GetInt("seed");
        }
            randomOffset = seed == 0 ? Random.Range(0f, 10000) : seed;
        shape = GetComponent<SpriteShapeController>();
        shape.spline.SetPosition(2, shape.spline.GetPosition(2) + Vector3.right * width);
        shape.spline.SetPosition(3, shape.spline.GetPosition(3) + Vector3.right * width);
        Vector3 localPos = shape.spline.GetPosition(2);
        endPos = shape.transform.TransformPoint(localPos);
        float dist = width / numberOfPoints;

        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector3 pos = shape.spline.GetPosition(i + 1);
            if (i == 0 || i == numberOfPoints - 1 || i == numberOfPoints - 2 || i == 1)
                shape.spline.InsertPointAt(i + 2, new Vector3(pos.x + dist, 0));
            else
                shape.spline.InsertPointAt(i + 2, new Vector3(pos.x + dist, amplitude * Mathf.PerlinNoise(i * frequency + randomOffset, 0), 0));
        }

        for (int i = 0; i < numberOfPoints; i++)
        {
            shape.spline.SetTangentMode(i + 2, ShapeTangentMode.Continuous);

            shape.spline.SetLeftTangent(i + 2, Vector3.left * 3);
            shape.spline.SetRightTangent(i + 2, Vector3.right * 3);
        }
        Instantiate(endpoint, (endPos + (new Vector3(-2,1,0) * endPointOffset)), Quaternion.identity);
    }


}
