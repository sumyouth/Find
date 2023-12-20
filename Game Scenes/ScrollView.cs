using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    private bool isDragging = false; // ���� �巡�� ������ ���θ� ��Ÿ���� ����
    private Vector3 dragStartPosition; // �巡�� ���� ������ �����ϴ� ����
    public float dragSpeed = 2f; // ī�޶� �巡�� �ӵ��� �����ϴ� ����

    void Update()
    {
        // ��ġ �Է� ó��
        if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0); // ù ��° ��ġ�� �����ɴϴ�.

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = true; // �巡�� ����
                    dragStartPosition = touch.position; // �巡�� ���� ���� ����
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // ��ġ ���� ������ ���� ��ġ ��ġ ���� ���̸� ����Ͽ� ī�޶� �̵�
                        Vector3 direction = Camera.main.ScreenToWorldPoint(touch.position) - Camera.main.ScreenToWorldPoint(dragStartPosition);
                        transform.Translate(-direction * dragSpeed * Time.deltaTime);
                        dragStartPosition = touch.position; // �巡�� ���� ������ ���� ��ġ ��ġ�� ������Ʈ
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false; // �巡�� ����
                    break;
            }
        }
    }
}
