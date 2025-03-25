using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour
{
    public Button SFXbutton;
    public Image btnImage;
    public Sprite PlayImage;
    public Sprite StopImage;
    private SFXManager sfxManager;  //SFXManager 참조
  
    public void Awake()
    {
        sfxManager = FindObjectOfType<SFXManager>();
        SFXbutton.onClick.AddListener(SwapeSprite);

        btnImage = SFXbutton.GetComponent<Image>();

        UpdateSprite();

    }

    private void SwapeSprite()
    {
        SFXManager.Instance.PlaySFX("ClickButton");  //효과음 재생
        UpdateSprite();
    }
    private void UpdateSprite()
    {
        btnImage.sprite = sfxManager.OnSFX ? PlayImage : StopImage;
    }
}
