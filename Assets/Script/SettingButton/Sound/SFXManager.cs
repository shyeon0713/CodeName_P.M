using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;  // AudioMixer Ȱ��
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ� 
    public static SFXManager Instance { get; private set; }
    // Instance�� �̱��� ���Ͽ��� ���Ǵ� ���������� �ǹ�
    //Ŭ������ �ϳ��� �ν��Ͻ��� �������� ������ �� �ֵ��� ����(����)

    public AudioSource SFX;
    public bool OnSFX = true;

    [System.Serializable]
    public struct SceneSFX
    {
        public string SFXName;  // ȿ���� �̸�
        public AudioClip SFXClip;
    }

    public SceneSFX[] SFXList;

   // public AudioMixer SoundControl;
  //  float volume;
   // public Slider SFXslider;  // UI Slider ����

    private void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �� ���� �� ����
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // ����� �ҽ� �������� (null ����)
        // -> ������ ����� ���, ���� ��ȯ�Ǹ鼭 ��Ȥ���ٰ� AudioSource�� Null���°� �Ǵ� ��� �߻�
        // ���� null�� �ƴ� ��츦 ������ �Ͽ� AudioSource�߰�
        SFX = GetComponent<AudioSource>();
        if (SFX == null)
        {
            SFX = gameObject.AddComponent<AudioSource>();
        }

        /*
        // ����� �ͼ� �ʱ� ����
        if (SoundControl != null)
        {
            SoundControl.GetFloat("sfxvolume", out volume);
            SFXslider.value = Mathf.Pow(10, volume / 20);  // UI �����̴� �ʱ� �� ����
            SFXslider.onValueChanged.AddListener(SetSFXVolume);
        }
        */
    }

    public void PlaySFX(string SFXName)
    {
        for (int i = 0; i < SFXList.Length; i++)
        {
            if (SFXList[i].SFXName == SFXName)
            {
                SFX.PlayOneShot(SFXList[i].SFXClip);  // ȿ���� �� �� ���
                return;
            }
        }
        Debug.LogWarning($"SFX '{SFXName}' not found!");
    }

    /*
    private void SetSFXVolume(float value)
    {
        SoundControl.SetFloat("sfxvolume", Mathf.Log10(value) * 20);
    }
    */



    //���� -> Scene�� ��ȯ�� ��� ���� Scene���� ������ ��������� �Ȱ��� ������� ����
    // �ذ��� -> Player.prefs�� ���� ��, ���� �� ����
    // Player.prefs�� ��� ���� ��ȯ�Ǹ鼭 �÷��̾ ���ӿ� �����ؾ� �� �κ��� ����
}
