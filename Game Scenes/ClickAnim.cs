using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    float time = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭을 감지
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                StartCoroutine(PlayFadeAnimation()); // 클릭 시 페이드 애니메이션 실행
            }
        }
    }

    IEnumerator PlayFadeAnimation()
    {
        float duration = 1f; // 애니메이션 지속 시간
        float targetAlpha = 0f; // 목표 알파값
        float startAlpha = GetComponent<SpriteRenderer>().color.a; // 시작 알파값

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

            Color currentColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            yield return null;
        }

        gameObject.SetActive(false); // 애니메이션이 끝나면 오브젝트를 비활성화합니다.
    }
}
