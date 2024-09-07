using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_469 : STG
{
     public float threshold = -20f; // dB �Ӱ谪 ����
    
    private AudioClip micClip;
    private bool isOverThreshold;

    void Start()
    {
        // ����ũ���� ����� �Է� ����
        micClip = Microphone.Start(null, true, 1, 44100);
    }

    void Update()
    {
        // ����ũ ���� ����
        float volume = GetMicVolume();
        //����Ʈ : -90
        //����ũ ũ�� : -50 ~ -5
        print("volume : " + volume);
        // ������ �Ӱ谪�� ������ �̺�Ʈ ����  
        if(volume > threshold && !isOverThreshold)
        {
            isOverThreshold = true;
            print("over");
        }
        else if(volume <= threshold)
        {
            isOverThreshold = false;  
        }
    }

    float GetMicVolume()
    {
        float levelMax = 0;
        float[] waveData = new float[128];
        int micPosition = Microphone.GetPosition(null) - 128 + 1;
        if (micPosition < 0) return 0;
        micClip.GetData(waveData, micPosition);

        // ����� �����Ϳ��� �ִ� ���� ���� ���
        for (int i = 0; i < 128; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return 20 * Mathf.Log10(Mathf.Sqrt(levelMax));
    }
}
