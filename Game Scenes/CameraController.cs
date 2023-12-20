using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetX = 10;
    public float offsetY = 10;
    public float offsetZ = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(Camera.main.transform.position.x, -offsetX, offsetX),
            Mathf.Clamp(Camera.main.transform.position.y, -offsetY, offsetY),
            Mathf.Clamp(Camera.main.transform.position.z, -offsetZ, offsetZ));
    }
}
