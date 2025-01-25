using UnityEngine;

public class Graph:MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField,Range(10,100)]
    public int resolution = 10;
    public int currentResolution;
    Transform[] points;

     void Awake()
    {
        currentResolution = resolution;
        changeResolution();
    }
    void changeResolution()
    {
        if (points != null)
        {
            foreach(Transform point in points)
            {
                if (point!=null)
                    Destroy(point.gameObject);
            }
        }
        Vector3 position = Vector3.zero;
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)

        {
            Debug.Log((i + 0.5f) * step - 1f);
            Transform point = Instantiate(pointPrefab);
            points[i] = point;
            position.x = (i + 0.5f) * step - 1f;

            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);

        }
    }
    void Update()
    {
        if (resolution != currentResolution)
        {
            currentResolution = resolution;
            changeResolution();
        }
        float time = Time.time;
        //Debug.Log(time);
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI*(position.x +time ));
            //Debug.Log(position.y);
            point.localPosition = position;
        }

    }

}
