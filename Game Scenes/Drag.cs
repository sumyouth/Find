using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    private bool isDragging = false; // 현재 드래그 중인지 여부를 나타내는 변수
    private Vector3 offset; // 위치 보정을 위한 벡터 값
    public float moveSpeed = 0.0000001f; // 드래그 속도 조절을 위한 변수
    public Camera mainCamera; // 카메라를 참조하기 위한 public 변수
    private float imageWidth = 1.18f;
    private float imageHeight = 1.18f;

    void Start()
    {
        // 카메라가 할당되지 않았다면 기본 카메라를 사용합니다.
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        Vector3 cameraPosition = new Vector3(0, 0, -10); // 카메라의 위치를 설정합니다.

        // 터치 입력 처리
        if (Input.touchCount > 0 && !IsPointerOverScrollview(Input.GetTouch(0).position))
        {
            Touch touch = Input.GetTouch(0); // 첫 번째 터치 입력을 가져옵니다.

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // 터치로 해당 오브젝트를 터치했을 때 드래그 시작
                    Vector3 touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        isDragging = true;
                        offset = transform.position - touchPos;
                    }
                    break;

                case TouchPhase.Moved:
                    // 드래그 중일 때, 오브젝트 이동 (moveSpeed를 고려하여 보간)
                    if (isDragging)
                    {
                        touchPos = mainCamera.ScreenToWorldPoint(touch.position);
                        transform.position = Vector3.Lerp(transform.position, new Vector3(touchPos.x + offset.x, touchPos.y + offset.y, transform.position.z), moveSpeed);
                    }
                    break;

                case TouchPhase.Ended:
                    // 터치가 끝났을 때 드래그 종료
                    isDragging = false;
                    break;
            }
        }

        // 마우스 입력 처리
        if (Input.GetMouseButtonDown(0) && !IsPointerOverScrollview(Input.mousePosition))
        {
            // 마우스로 해당 오브젝트를 클릭했을 때 드래그 시작
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = transform.position - mousePos;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // 마우스를 드래그 중일 때, 오브젝트 이동 (moveSpeed를 고려하여 보간)
            if (isDragging)
            {
                Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector3.Lerp(transform.position, new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, transform.position.z), moveSpeed);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 마우스 클릭이 끝났을 때 드래그 종료
            isDragging = false;
        }
    }

    bool IsPointerOverScrollview(Vector2 touchPosition)
    {
        // UI 요소 위에 있는지 여부를 확인하여 스크롤뷰 위에 있는지 검사합니다.
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<ScrollRect>() != null)
            {
                return true; // 스크롤뷰 위에 있음
            }
        }
        return false; // 스크롤뷰 위에 없음
    }
}
