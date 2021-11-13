using UnityEngine;

public class Record : MonoBehaviour
{
    private const int VOLUME_DATA_LENGTH = 128;//录制的声音长度
    private const int frequency = 44100;//码率
    private const int lengthSec = 999;//录制时长

    private string mDeviceName;//设备名称

    private AudioClip clip;//录制的音频

    public float volume;//音量

    private void Start()
    {
        //获取设备名称
        Debug.Log("Start recording");
        mDeviceName = Microphone.devices[0];
        //录制一段音频
        clip = Microphone.Start(mDeviceName, true, lengthSec, frequency);
    }

    void Update()
    {
        volume = GetMaxVolume();
        //Debug.Log("Max Volume = " + volume);
    }

    //获取音量
    private float GetMaxVolume()
    {
        float maxVolume = 0f;

        //用于储存一段时间内的音频信息
        float[] volumeData = new float[VOLUME_DATA_LENGTH];

        //获取录制的音频的开头位置
        int offset = Microphone.GetPosition(mDeviceName) - VOLUME_DATA_LENGTH + 1;

        if (offset < 0)
        {
            return 0f;
        }

        //获取数据
        clip.GetData(volumeData, offset);

        //解析数据
        for (int i = 0; i < VOLUME_DATA_LENGTH; i++)
        {
            float tempVolume = volumeData[i];
            if (tempVolume > maxVolume)
            {
                maxVolume = tempVolume;
            }
        }
        return maxVolume;
    }
}