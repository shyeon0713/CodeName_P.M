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

   //public AudioMixer SoundControl; // 만들어둔 오디오 믹서
   // float volume;  
  //  public Slider BGMslider;  //BGMSlider -> Slider UI까지 조절, 오디오믹서가 작동하지 않는 문제발생하여 우선 Manager에 넣어 진행


    private void Awake()
    {

       // BGMslider.value = 0.5f;  // volume UI 초기 설정 -> 50정도 
       // SoundControl.SetFloat("bgmvolume", Mathf.Log10(BGMslider.value) * 20); // volume -> 50으로
 
       // BGMslider.onValueChanged.AddListener(SetBGMVolume);


        // 싱글톤 패턴 적용 (중복 생성 방지)
        if (FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        BGM = GetComponent<AudioSource>();  // 기존 AudioSource 사용 \
                                            // (gameObject.AddComponent<AudioSource>() 활용 시, 새로운 AudioSource추가
                                            // AudioMixer를 설정해두어도 새로운 AudioSource를 추가하고 있기에
                                            // inspector에서 설정한 값이 제대로 적용되지 않음



        // 씬이 바뀔 때마다 BGM 변경
        SceneManager.sceneLoaded += OnSceneLoaded;

        // 현재 씬의 BGM 설정
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
                if (BGM.clip != BGMList[i].bgmClip)  // 같은 곡이면 변경 X
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
    }

    /*  private void SetBGMVolume(float Slidervalue)    //Slider UI
      {
          SoundControl.SetFloat("bgmvolume", Mathf.Log10(Slidervalue) * 20);
          // Volume 값이 데시벨이기 때문에 고정적인 간격을 가지지 못함으로 Log10 사용
      }
    */

    //문제 -> Scene를 전환할 경우 이전 Scene에서 저장한 볼륨기록이 똑같이 적용되지 않음
    // 해결방안 -> Player.prefs를 만든 후, 설정 값 저장
    // Player.prefs의 경우 씬이 전환되면서 플레이어가 게임에 저장해야 할 부분을 저장
}

