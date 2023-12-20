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

        // scroll < 0; scroll down�ϸ� ZoomIn
        if(Camera.orthographicSize <=2.67f&&scroll>0)
        {
            temp_value = Camera.orthographicSize;
            Camera.orthographicSize = temp_value; // maximize zoom in
            //�ִ�� ���� ���� �� Ư�� ���� �������� ��?
            // �ִ� �� �� ������ ����� ���� ���߱� ���� �� �� �� �ƿ� �Ǵ� ���� ����
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
