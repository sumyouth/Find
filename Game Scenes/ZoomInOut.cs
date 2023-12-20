using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public float speed = 10.0f;
    private float temp_value;
    Camera Camera;

    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

        // scroll < 0; scroll down하면 ZoomIn
        if(Camera.orthographicSize <=2.67f&&scroll>0)
        {
            temp_value = Camera.orthographicSize;
            Camera.orthographicSize = temp_value; // maximize zoom in
            //최대로 줌인 했을 때 특정 값을 지정했을 때?
            // 최대 줌 인 범위를 벗어나면 값에 맞추기 위해 한 번 줌 아웃 되는 현상 방지
        }
        else if(Camera.orthographicSize >= 7.03f && scroll < 0)
        {
            temp_value = Camera.orthographicSize;
            Camera.orthographicSize = temp_value;
        }

        else
            Camera.orthographicSize -= scroll * 0.5f;
    }
}
