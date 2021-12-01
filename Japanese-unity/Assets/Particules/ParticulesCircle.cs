using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public int countMeshs = 400;
    public Transform Center;
    public float Radius;
    public GameObject[] ListeObjects;
    public GameObject[] ListeRenderObjects;

    public float TIMEE;
    void Start()
    {
        ListeRenderObjects = new GameObject[countMeshs];

        for (int i = 0; i < countMeshs; i++)
        {
            ListeRenderObjects[i] = Instantiate(ListeObjects[Random.Range( 0, ListeObjects.Length )], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < countMeshs; i++)
        {
            float posI = (float)i / (float)countMeshs;
            float time = (Time.realtimeSinceStartup * 1f) + (posI * (Mathf.PI * 4f));
            Debug.Log($"Time {i} {time} {countMeshs} / {posI}");
            float x = Center.position.x + Mathf.Cos(time) * Radius;
            float y = Center.position.y;
            float z = Center.position.z + Mathf.Sin(time) * Radius;

            ListeRenderObjects[i].transform.position = new Vector3( x, y, z );
        }
    }
}
