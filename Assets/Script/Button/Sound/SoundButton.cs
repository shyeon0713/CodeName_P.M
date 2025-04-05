using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Button Soundbutton;  // 버튼
    public Image btnImage;  // 버튼 이미지
    public Sprite PlaySprite;  // Play 버튼 이미지
    public Sprite StopSprite;  // Stop 버튼 이미지
    private SoundManager soundManager;  // SoundManager 참조

    public void Awake()
    {
        // SoundManager 참조 찾기
        soundManager = FindObjectOfType<SoundManager>();
        Soundbutton.onClick.AddListener(SwapeSprite);

        btnImage = Soundbutton.GetComponent<Image>();

        // 초기 버튼 이미지 설정
        UpdateSprite();
    }

    private void SwapeSprite()
    {
        soundManager.PlaySound();   //soundManager의 PlayMusic()을 참조
        UpdateSprite();
    }
    private void UpdateSprite()
    {
        btnImage.sprite = soundManager.OnSound ? PlaySprite : StopSprite;
    }
}
