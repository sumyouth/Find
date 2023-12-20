using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    float time = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ���� ����
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                StartCoroutine(PlayFadeAnimation()); // Ŭ�� �� ���̵� �ִϸ��̼� ����
            }
        }
    }

    IEnumerator PlayFadeAnimation()
    {
        float duration = 1f; // �ִϸ��̼� ���� �ð�
        float targetAlpha = 0f; // ��ǥ ���İ�
        float startAlpha = GetComponent<SpriteRenderer>().color.a; // ���� ���İ�

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

            Color currentColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            yield return null;
        }

        gameObject.SetActive(false); // �ִϸ��̼��� ������ ������Ʈ�� ��Ȱ��ȭ�մϴ�.
    }
}
