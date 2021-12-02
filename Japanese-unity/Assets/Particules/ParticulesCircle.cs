using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ParticulesCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public int Count = 50;
    public GameObject[] Prefabs;
    public Material[] Materials;
    private GameObject[] RenderObjects;
    private float[] RenderObjectsPosition;
    private Vector3[] RenderObjectsVector;
    public float ScaleObjects = 0.1f;

    // PATH
    public float Speed = 0.3f;

    public PathCreator pathEnd;
    public bool DoPath;

    private float endCirclePath = 3.263377f;
    private float endPath;

    void Start()
    {   
        RenderObjects = new GameObject[Count];
        RenderObjectsPosition = new float[Count];
        RenderObjectsVector = new Vector3[Count];

        endPath = pathEnd.path.length;

        for (int i = 0; i < Count; i++)
        {
            int random = Random.Range( (int)0, (int)Prefabs.Length );
            RenderObjects[i] = Instantiate(Prefabs[random], new Vector3(0, 0, 0), Quaternion.identity);
            RenderObjects[i].GetComponent<Renderer>().material = Materials[Random.Range(0,Materials.Length)];

            RenderObjects[i].transform.localScale = new Vector3(ScaleObjects, ScaleObjects, ScaleObjects);
            RenderObjects[i].transform.localRotation = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            
            RenderObjectsPosition[i] = ((float)i / (float)Count) * (float)endCirclePath;
            RenderObjectsVector[i] = new Vector3(Random.Range(0, 0.2f), Random.Range(0, 0.2f), Random.Range(0, 0.2f));
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Count; i++)
        {
            RenderObjectsPosition[i] += Speed * Time.deltaTime;
            if (!DoPath) RenderObjectsPosition[i] = RenderObjectsPosition[i] % endCirclePath;
            RenderObjects[i].transform.position = pathEnd.path.GetPointAtDistance(RenderObjectsPosition[i], PathCreation.EndOfPathInstruction.Stop);
            RenderObjects[i].transform.position += RenderObjectsVector[i];
        }
    }
}
