using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Dictionary<GameObject, bool> isClickedDict = new Dictionary<GameObject, bool>();
    int score = 0;
    public Text scoreText;

    void Start()
    {
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        LoadScore();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Image");
        foreach (var obj in objects)
        {
            isClickedDict[obj] = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject != this.gameObject)
            {
                if (!isClickedDict[hit.collider.gameObject])
                {
                    Debug.Log("찾았다!!!!");
                    IncreaseScore(1);
                    isClickedDict[hit.collider.gameObject] = true;
                    SaveScore();
                }
            }
        }
    }

    void IncreaseScore(int amount)
    {
        score += amount;
        if (score >= 5) // 점수가 5 이상일 때 초기화
        {
            score = 0;
        }
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = " " + score.ToString() + " / 5";
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }

    void LoadScore()
    {
        score = PlayerPrefs.GetInt("PlayerScore", 0);
        UpdateScoreText();
    }
}
