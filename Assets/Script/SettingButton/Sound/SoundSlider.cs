using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;   //AudioMixer

public class SoundSlider : MonoBehaviour
{
    public Slider bgmslider;
    public AudioMixer SoundControl; // ������ ����� �ͼ�

  // private SoundManager soundManager;

    // Update is called once per frame
    public void Awake()
    {

        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);  // ����� ������ �ҷ����� (������ 0.5f)

        bgmslider.value = savedVolume;
        SetBGMVolume(savedVolume);  // �ʱ� ����� ������ ����

        bgmslider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void SetBGMVolume(float slidervalue)    //Slider UI
    { // ���ú� ��ȯ �� ����� �ͼ��� ����
        SoundControl.SetFloat("bgmvolume", Mathf.Log10(slidervalue) * 20);
        // Volume ���� ���ú��̱� ������ �������� ������ ������ �������� Log10 ���

        // ����
        PlayerPrefs.SetFloat("BGMVolume", slidervalue);
        PlayerPrefs.Save();
    }
}
