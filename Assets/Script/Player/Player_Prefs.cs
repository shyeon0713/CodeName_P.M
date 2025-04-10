using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Prefs : MonoBehaviour
{

	public void GameSave(int datenumber, bool systemProgress)
	{
		PlayerPrefs.SetInt("DateNumber", datenumber);
		PlayerPrefs.SetInt("SystemProgress", systemProgress ? 1 : 0);  //int형으로 저장 -> PlayerPrefs에는 SetBool(),GetBool()이 없음

		PlayerPrefs.Save();   //프리팹에 저장
	}

	public void GameLoad(out int dateNumber, out bool systemProgress)
	//out:C#에서 저장된 값을 한 번에 여러개 불러오고 싶을 때 활용
	{
		dateNumber = PlayerPrefs.GetInt("DateNumber", 0);
		systemProgress = PlayerPrefs.GetInt("SystemProgress", 0) == 1;
	}

	public void SaveSetting(float bgm, float sfx, bool bgmon, bool sfxon)  // 기본 세팅 저장
	{
		PlayerPrefs.SetFloat("BGMVolume", bgm);
		PlayerPrefs.SetFloat("SFXVolume", sfx);
		PlayerPrefs.SetInt("BGMOn", bgmon ? 1 : 0);   //bool 대신 int 활용
		PlayerPrefs.SetInt("SFXON", sfxon ? 1 : 0);  //bool 대신 int 활용

		PlayerPrefs.Save();   //프리팹에 저장
	}

	public void LoadSetting(out float bgm, out float sfx, out bool bgmon, out bool sfxon) // 기본 세팅 로드
	{
		bgm = PlayerPrefs.GetFloat("BGMVolume", 1.0f); // 없으면 기본값 1.0f
		sfx = PlayerPrefs.GetFloat("SFXVolume", 1.0f); // 없으면 기본값 1.0f
		bgmon = PlayerPrefs.GetInt("BGM_ON", 1) == 1;
		sfxon = PlayerPrefs.GetInt("SFX_ON", 1) == 1;
	}

	 public void SaveQuest(string questKey, int progress, bool completed)
	{
		PlayerPrefs.SetString("QuestKey", questKey);
		PlayerPrefs.SetInt("QuestProgress", progress);
		PlayerPrefs.SetInt("QuestCompleted", completed ? 1 : 0);
		
		PlayerPrefs.Save(); //프리팹에 저장
	}

	public void LoadQuest(out string questKey, out int progress, out bool completed)
	{
		questKey = PlayerPrefs.GetString("QuestKey", "");
		progress = PlayerPrefs.GetInt("QuestProgress", 0);
		completed = PlayerPrefs.GetInt("QuestCompleted", 0) == 1;
	}

}



