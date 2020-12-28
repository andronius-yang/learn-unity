using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10,1000)] public int resolution;
    private Transform[] points;
    void Awake(){
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = new Vector3(0, 0, 0);
        points = new Transform[resolution];
        for(int i = 0; i<resolution; i++){
            Transform point = Instantiate(pointPrefab);    
            position.x = (i+0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    void Update()
    {
        for(int i = 0; i<points.Length; i++){
            Transform point = points[i];
            Vector3 pos = point.localPosition;
            pos.y = Mathf.Sin(Mathf.PI * Mathf.Pow((pos.x + (Time.fixedTime/10)),2));
            point.localPosition = pos;
        }
    }
}
