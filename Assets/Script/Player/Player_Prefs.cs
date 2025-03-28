using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Prefs : MonoBehaviour
{

	public int Datenumber;
	public void GameSave()
	{
	//	PlayerPrefs.SetInt("Datenumber", );
	   // Player의 현재 진행 상황
	   // 1. 날짜 및 요일
	   // 2. 어떤 시스템까지 진행했는지
	   // 3. 설정한 기본 설정 -> Sound, Sfx, 
	   PlayerPrefs.Save();
	}

	public void GameLoad()
	{

		// 로드 시 예외 처리
		// if (!PlayerPrefs.HasKey("변수 이름"))
		//  return;  //load하지 말기


		//float 변수 값 = PlayerPrefs.Get변수형("변수이름");
	}

	public void SaveSetting()  //기본 세팅 저장
    {

    }

}
