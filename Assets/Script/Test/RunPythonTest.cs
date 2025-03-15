using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class RunPythonTest : MonoBehaviour
{
    public void RunPythonScript()
    {
        UnityEngine.Debug.Log("RunPythonScript() �Լ��� �����");

        //��� ��� ����
        string scriptPath = Path.Combine(Application.dataPath, "Script", "PythonScript", "test_main.py");

        // ���� ���� ���� Ȯ��
        if (!File.Exists(scriptPath)){
            UnityEngine.Debug.LogError("Python script not found: " + scriptPath);
            return;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "C:\\Users\\lyj\\AppData\\Local\\Programs\\Python\\Python313\\python.exe";
        startInfo.Arguments = scriptPath;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;

        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            if (output == null){
                UnityEngine.Debug.Log("Python ���� ����");
            }
            UnityEngine.Debug.Log("Python Output: " + output);

            process.WaitForExit();
        }
    }
}
