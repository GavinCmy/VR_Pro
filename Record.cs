using UnityEngine;

public class Record : MonoBehaviour
{
    private const int VOLUME_DATA_LENGTH = 128;//¼�Ƶ���������
    private const int frequency = 44100;//����
    private const int lengthSec = 999;//¼��ʱ��

    private string mDeviceName;//�豸����

    private AudioClip clip;//¼�Ƶ���Ƶ

    public float volume;//����

    private void Start()
    {
        //��ȡ�豸����
        Debug.Log("Start recording");
        mDeviceName = Microphone.devices[0];
        //¼��һ����Ƶ
        clip = Microphone.Start(mDeviceName, true, lengthSec, frequency);
    }

    void Update()
    {
        volume = GetMaxVolume();
        //Debug.Log("Max Volume = " + volume);
    }

    //��ȡ����
    private float GetMaxVolume()
    {
        float maxVolume = 0f;

        //���ڴ���һ��ʱ���ڵ���Ƶ��Ϣ
        float[] volumeData = new float[VOLUME_DATA_LENGTH];

        //��ȡ¼�Ƶ���Ƶ�Ŀ�ͷλ��
        int offset = Microphone.GetPosition(mDeviceName) - VOLUME_DATA_LENGTH + 1;

        if (offset < 0)
        {
            return 0f;
        }

        //��ȡ����
        clip.GetData(volumeData, offset);

        //��������
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