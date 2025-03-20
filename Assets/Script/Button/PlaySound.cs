using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button playButton;  // 버튼
    public Image btnImage;  // 버튼 이미지
    public Sprite PlaySprite;  // Play 버튼 이미지
    public Sprite StopSprite;  // Stop 버튼 이미지
    private SoundManager soundManager;  // SoundManager 참조

    public void Awake()
    {
        // SoundManager 참조 찾기
        soundManager = FindObjectOfType<SoundManager>();
        playButton.onClick.AddListener(SwapeSprite);

        btnImage = playButton.GetComponent<Image>();

        // 초기 버튼 이미지 설정
        if (btnImage != null && PlaySprite != null)
        {
            btnImage.sprite = PlaySprite; 
        }
    }

    public void SwapeSprite()
    {
        // 버튼 이미지 변경
        if (soundManager.isPlaying)
        {
            btnImage.sprite = PlaySprite;
        }
        else
        {
            btnImage.sprite = StopSprite;
        }

        soundManager.PlayMusic();  // 음악을 재생하거나 일시 정지
    }
}
