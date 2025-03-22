using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{  // Sound를 관리하는 Manager 스크립트를 각자 제작하여 버튼을 누르거나 상호작용을 할 경우, 참조하여 활용
    public AudioSource SFX;  //사용처에 따라 버튼 이름 변경
    public bool OnSFX = true;

    [System.Serializable]
    public struct SceneSFX
    {
        public string SFXName;  //효과음 종류 작성
        public AudioClip bgmClip;
    }
    public SceneSFX[] SFXList;

    private void Awake()
    {
        // 싱글톤 패턴 적용 (중복 생성 방지)
        if (FindObjectsOfType<SFXManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SFX = gameObject.AddComponent<AudioSource>();

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

                if(SFX.clip != SFXList[i].bgmClip)  //같을 경우 변경 X
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
}
