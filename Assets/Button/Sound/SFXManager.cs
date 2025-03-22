using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{  // Sound�� �����ϴ� Manager ��ũ��Ʈ�� ���� �����Ͽ� ��ư�� �����ų� ��ȣ�ۿ��� �� ���, �����Ͽ� Ȱ��
    public AudioSource SFX;  //���ó�� ���� ��ư �̸� ����
    public bool OnSFX = true;

    [System.Serializable]
    public struct SceneSFX
    {
        public string SFXName;  //ȿ���� ���� �ۼ�
        public AudioClip bgmClip;
    }
    public SceneSFX[] SFXList;

    private void Awake()
    {
        // �̱��� ���� ���� (�ߺ� ���� ����)
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
}
