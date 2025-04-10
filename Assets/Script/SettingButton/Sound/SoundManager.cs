using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;   //AudioMixer
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Scene

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public bool OnSound = true;

    [System.Serializable]
    public struct SceneBGM
    {
        public string sceneName;
        public AudioClip bgmClip;
    }

    public SceneBGM[] BGMList;

   //public AudioMixer SoundControl; // ������ ����� �ͼ�
   // float volume;  
  //  public Slider BGMslider;  //BGMSlider -> Slider UI���� ����, ������ͼ��� �۵����� �ʴ� �����߻��Ͽ� �켱 Manager�� �־� ����


    private void Awake()
    {

       // BGMslider.value = 0.5f;  // volume UI �ʱ� ���� -> 50���� 
       // SoundControl.SetFloat("bgmvolume", Mathf.Log10(BGMslider.value) * 20); // volume -> 50����
 
       // BGMslider.onValueChanged.AddListener(SetBGMVolume);


        // �̱��� ���� ���� (�ߺ� ���� ����)
        if (FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        BGM = GetComponent<AudioSource>();  // ���� AudioSource ��� 
                                            // (gameObject.AddComponent<AudioSource>() Ȱ�� ��, ���ο� AudioSource�߰�
                                            // AudioMixer�� �����صξ ���ο� AudioSource�� �߰��ϰ� �ֱ⿡
                                            // inspector���� ������ ���� ����� ������� ����

        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1.0f); // Player_prefs.cs�� ����� ���� ��������
        BGM.volume = bgmVolume;

        OnSound = PlayerPrefs.GetInt("BGM_ON", 1) == 1;

        // ���� �ٲ� ������ BGM ����
        SceneManager.sceneLoaded += OnSceneLoaded;

        // ���� ���� BGM ����
        SetBGM(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetBGM(scene.name);
    }

    public void SetBGM(string sceneName)
    {
        for (int i = 0; i < BGMList.Length; i++)
        {
            if (BGMList[i].sceneName == sceneName)
            {
                if (BGM.clip != BGMList[i].bgmClip)  // ���� ���̸� ���� X
                {
                    BGM.clip = BGMList[i].bgmClip;
                    if (OnSound)
                    {
                        BGM.Play();
                    }
                }
                return;
            }
        }
      
    }

    public void PlaySound()
    {
        if (OnSound)
            BGM.Pause();
        else
            BGM.Play();

        OnSound = !OnSound;

        PlayerPrefs.SetInt("BGM_ON", OnSound ? 1 : 0);
        PlayerPrefs.Save();
    }


    //���� -> Scene�� ��ȯ�� ��� ���� Scene���� ������ ��������� �Ȱ��� ������� ����
    // �ذ��� -> Player.prefs�� ���� ��, ���� �� ����
    // Player.prefs�� ��� ���� ��ȯ�Ǹ鼭 �÷��̾ ���ӿ� �����ؾ� �� �κ��� ����
}

