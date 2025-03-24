using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;  // AudioMixer Ȱ��
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{ 
    // Sound�� �����ϴ� Manager ��ũ��Ʈ�� ���� �����Ͽ� ��ư�� �����ų� ��ȣ�ۿ��� �� ���, �����Ͽ� Ȱ��
    public AudioSource SFX;  //���ó�� ���� ��ư �̸� ����
    public bool OnSFX = true;

    [System.Serializable]
    public struct SceneSFX
    {
        public string SFXName;  //ȿ���� ���� �ۼ�
        public AudioClip bgmClip;
    }

    public SceneSFX[] SFXList;

    public AudioMixer SoundControl;
    float volume;  
    public Slider SFXslider;   //Slider ���� -> SFXMananger���� �� ����


    private void Awake()
    {
        SoundControl.GetFloat("sfxvolume", out volume);
        SFXslider.value = 0.3f;  // volume �� �ʱ� ���� -> 50����

        SFXslider.onValueChanged.AddListener(SetSFXVolume); 

        // �̱��� ���� ���� (�ߺ� ���� ����)
        if (FindObjectsOfType<SFXManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SFX = GetComponent<AudioSource>();  //SoundManager�� BGM�κ� ������ ���� -> GetComponent<AudioSource>()�� ����

        SetSFX(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoad (Scene scene, LoadSceneMode mode)
    {
        SetSFX(scene.name);
    }
  
    public void SetSFX(string SFXName)
    {
        for (int i= 0; i < SFXList.Length; i++)
        {
            if(SFXList[i].SFXName == SFXName)
            {

                if(SFX.clip != SFXList[i].bgmClip)  //���� ��� ���� X
                {
                    SFX.clip = SFXList[i].bgmClip;
                    if (OnSFX)
                    {
                        SFX.Play(); 
                    }
                }


                return;
            }
        }

    }

    public void PlaySFX()
    {
        if (OnSFX)
            SFX.Pause();
        else
            SFX.Play();

        OnSFX = !OnSFX;
    }
    private void SetSFXVolume(float value)
    {
        SoundControl.SetFloat("sfxvolume", Mathf.Log10(value) * 20);
    }
}
