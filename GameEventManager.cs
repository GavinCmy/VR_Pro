using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventManager : MonoBehaviour
{

    public GameObject _chuan,_chuangjiang;
    public Text _tips;
    public bool _tipsBool1, _tipsBool2,_tipsBool3, _tipsBool4, _tipsBool5, _tipsBool6, _tipsBool7;

    public bool chuanMove;
    public float chuanSpeed=1;

    void Start()
    {
        
    }

  
    void Update()
    {
        



        Debug.Log(Vector3.Distance(transform.localPosition, _chuangjiang.transform.localPosition));
        if (Vector3.Distance(transform.localPosition,_chuan.transform.localPosition)<=10&& !_tipsBool1)
        {
            StartCoroutine(Showtips(0.1f, "任务1：找到岛上的船桨"));
            Invoke("ClearTips",5);
            _tipsBool1 = true;
        }

        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.TriggerPressDown, () => {

            //todo:加入手柄按键再获取
            if (Vector3.Distance(transform.localPosition, _chuangjiang.transform.localPosition) <= 10 && _tipsBool1 && !_tipsBool2)
            {
                _chuangjiang.SetActive(false);
                StartCoroutine(Showtips(0.1f, "获得船桨"));
                StartCoroutine(Showtips(2, "任务2：划船到对岸，寻找音乐之花"));
                Invoke("ClearTips", 5);
                _tipsBool2 = true;
            }
        });




        //todo:加入手柄按键再上船

        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.TriggerPressDown, () => {
            if ( Vector3.Distance(transform.localPosition, _chuan.transform.localPosition) <= 10 && _tipsBool1 && _tipsBool2 && !_tipsBool3)
            {
                StartCoroutine(Showtips(0.1f, "上船了"));
                //todo:上船
                _chuan.transform.localPosition = new Vector3(-9.29f, 16.66f, 4.77f);
                _chuan.transform.localEulerAngles = new Vector3(0, -200, 0);
                transform.GetComponent<BoatMove>().enabled = false;
                transform.SetParent(_chuan.transform);
                transform.localPosition = new Vector3(0, 1.7f, 0);
                Invoke("ChuangMove", 2);
                Invoke("ClearTips", 5);
                _tipsBool3 = true;
            }

        });

        //todo:深呼吸结束，继续行驶
        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.TriggerPressDown, () => {
            if (_tipsBool1 && _tipsBool2 && _tipsBool3 && _tipsBool4&&!_tipsBool5)
            {
                HeiWuOver();
                ChuangMove();
                _tipsBool5 = true;
            }

        });

        //todo:自由放松结束，继续行驶
        HandClickManager.Instance.HandClickOperation(this.gameObject, HandType.BothHands, HandKeyType.TriggerPressDown, () => {
            if (_tipsBool1 && _tipsBool2 && _tipsBool3 && _tipsBool4 && _tipsBool5 && _tipsBool6)
            {
                HeiWuOver_2();
                ChuangMove();
                _tipsBool6 = false;
            }

        });

        //
        //
        //
        //

        if (chuanMove)
        {
            _chuan.transform.Translate(Vector3.right * chuanSpeed, Space.Self);
        }

       
    }

    void ChuangMove()
    {
        chuanMove = true;
       
    }


    void ClearTips()
    {
        _tips.text = "";
        _tips.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator Showtips(float _time,string tip)
    {
        yield return new WaitForSeconds(_time);
        _tips.transform.parent.gameObject.SetActive(true);
        _tips.text = tip;
    }

    public GameObject heiWu, heiWu_2;
    public GameObject yuYing;
    public GameObject lightObj;
    public float yuyingTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name== "heiwuCollider")
        {
            chuanMove = false;
            StartCoroutine(Showtips(0.1f, "任务3：你现在驶入了迷雾，请用内心的宁静力量驱散迷雾"));
            Invoke("ClearTips", 5);
            //todo:显示黑雾特效 ,天空变暗
            heiWu.gameObject.SetActive(true);
            lightObj.GetComponent<Light>().intensity = 0;
            //todo:播放音频
            yuYing.gameObject.SetActive(true);

            
            Invoke("YuYingOver", yuyingTime);
         
        }

        if (other.gameObject.name == "heiwuCollider_2")
        {
            chuanMove = false;
            StartCoroutine(Showtips(0.1f, "任务4："));
            Invoke("ClearTips", 5);
            //todo:显示黑雾特效 ,天空变暗
            heiWu_2.gameObject.SetActive(true);
            lightObj.GetComponent<Light>().intensity = 0;
            //todo:播放音频
            //yuYing.gameObject.SetActive(true);
            Invoke("Bequiet", 10f);
        }

        if (other.gameObject.name == "zhongdianCollider")
        {
            chuanMove = false;
            StartCoroutine(Showtips(0.1f, "上岸了"));
            Invoke("ClearTips", 5);

            //todo:下船
            //transform.GetComponent<BoatMove>().enabled = false;
            //transform.SetParent(_chuan.transform);
            _chuan.transform.DetachChildren();
            transform.localPosition = new Vector3(-315f, 23.9f, -125.8f);
            transform.GetComponent<BoatMove>().enabled = true;
        }
    }

    void YuYingOver()
    {
        _tipsBool4 = true;
    }

    void Bequiet()
    {
        _tipsBool6 = true;
    }


    void HeiWuOver()
    {
        heiWu.gameObject.SetActive(false);
        lightObj.GetComponent<Light>().intensity = 1;
        yuYing.gameObject.SetActive(false);
    }

    void HeiWuOver_2()
    {
        heiWu_2.gameObject.SetActive(false);
        lightObj.GetComponent<Light>().intensity = 1;
    }
}
