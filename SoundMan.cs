using UnityEngine;

public class SoundMan : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource bgm;

    void Start()
    {
        // AudioSource 컴포넌트를 가져와서 bgm 변수에 할당합니다.
        bgm = GetComponent<AudioSource>();

        if (bgm != null && backgroundMusic != null)
        {
            // 배경 음악을 설정합니다.
            bgm.clip = backgroundMusic;
            bgm.loop = true;

            // 배경 음악을 재생합니다.
            bgm.Play();
        }
    }
}