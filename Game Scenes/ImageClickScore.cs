// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class ImageClickScore : MonoBehaviour, IPointerClickHandler
// {
//     private int score = 0; // 클릭한 횟수를 저장할 변수
//     public Text scoreText; // UI Text 요소를 Inspector에서 연결할 변수

//     void Start()
//     {
//         // scoreText 변수가 비어있다면
//         if (scoreText == null)
//         {
//             // GameObject.Find를 사용하여 ScoreText라는 이름의 Text 요소를 찾아 연결합니다.
//             scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
//         }
//     }

//     // 이미지가 클릭되었을 때 실행되는 함수
//     public void OnPointerClick(PointerEventData eventData)
//     {
//         IncreaseScore(1); // 클릭할 때마다 점수를 증가시키는 함수 호출
//     }

//     // 점수를 증가시키는 함수
//     void IncreaseScore(int amount)
//     {
//         score += amount; // 점수를 증가시킴
//         UpdateScoreUI(); // UI에 현재 점수를 업데이트하는 함수 호출
//     }

//     // UI Text에 현재 점수를 표시하는 함수
//     void UpdateScoreUI()
//     {
//         scoreText.text = " " + score.ToString() + " / 25"; // UI Text에 점수를 표시
//     }
// }
