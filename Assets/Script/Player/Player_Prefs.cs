using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Prefs : MonoBehaviour
{

	public int Datenumber;
	public void GameSave()
	{
	//	PlayerPrefs.SetInt("Datenumber", );
	   // Player�� ���� ���� ��Ȳ
	   // 1. ��¥ �� ����
	   // 2. � �ý��۱��� �����ߴ���
	   // 3. ������ �⺻ ���� -> Sound, Sfx, 
	   PlayerPrefs.Save();
	}

	public void GameLoad()
	{

		// �ε� �� ���� ó��
		// if (!PlayerPrefs.HasKey("���� �̸�"))
		//  return;  //load���� ����


		//float ���� �� = PlayerPrefs.Get������("�����̸�");
	}

	public void SaveSetting()  //�⺻ ���� ����
    {

    }

}
