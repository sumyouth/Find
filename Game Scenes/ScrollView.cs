using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    private bool isDragging = false; // 현재 드래그 중인지 여부를 나타내는 변수
    private Vector3 dragStartPosition; // 드래그 시작 지점을 저장하는 변수
    public float dragSpeed = 2f; // 카메라 드래그 속도를 조절하는 변수

    void Update()
    {
        // 터치 입력 처리
        if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            Touch touch = Input.GetTouch(0); // 첫 번째 터치를 가져옵니다.

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = true; // 드래그 시작
                    dragStartPosition = touch.position; // 드래그 시작 지점 저장
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // 터치 시작 지점과 현재 터치 위치 간의 차이를 계산하여 카메라 이동
                        Vector3 direction = Camera.main.ScreenToWorldPoint(touch.position) - Camera.main.ScreenToWorldPoint(dragStartPosition);
                        transform.Translate(-direction * dragSpeed * Time.deltaTime);
                        dragStartPosition = touch.position; // 드래그 시작 지점을 현재 터치 위치로 업데이트
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false; // 드래그 종료
                    break;
            }
        }
    }
}
