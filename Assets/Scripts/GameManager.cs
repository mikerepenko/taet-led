﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Common;
using AppodealAds.Unity.Api;

public class GameManager : MonoBehaviour, IRewardedVideoAdListener
{


    #region Rewarded Video callback handlers
    public void onRewardedVideoLoaded() {  }
    public void onRewardedVideoFailedToLoad() {  }
    public void onRewardedVideoShown() {  }
    public void onRewardedVideoClosed() {  }
    public void onRewardedVideoFinished(int amount, string name)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 500);
        MaxMoney.text = PlayerPrefs.GetInt("Money").ToString();
		podarok.SetActive (true);

    }
    #endregion
    //public int money;
    public Text MaxMoney;
    public Text record;
    public Text thisScore;
    public int scoreCount = 0;
    public GameObject newRecord;
    public bool isManager;
    private int gM;
    public int count;
    private int countGameover;
    public AudioSource buyAds;
    public GameObject goButtom;
    public Text award;
    public GameObject firstMoney;
    private int rund;
    private bool isRecord;

    //Рекорды выноска
    public GameObject yourRecord;
    public Text top;
	public GameObject podarok;
	public GameObject reviews;


    void Awake()
    {
        //Обратный вызов
        Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
        string appKey = "2702ea8d0d4fe4af62345194dd9c6c70a6cb162def901868";
        Appodeal.disableLocationPermissionCheck();
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        Appodeal.setRewardedVideoCallbacks(this);
        Appodeal.setTesting(false);
    }

    public void StopBanner()
    {
        Appodeal.hide(Appodeal.BANNER_BOTTOM);
        Appodeal.hide(Appodeal.INTERSTITIAL);
    }

    public void StartCallBack()
    {
       //Проверка наличия интернета
        if(Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
            Appodeal.show(Appodeal.REWARDED_VIDEO);
    }

    public void StartInterstitial()
    {
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            Appodeal.show(Appodeal.INTERSTITIAL);
    }

    public void StartSkippable()
    {
        if (Appodeal.isLoaded(Appodeal.SKIPPABLE_VIDEO))
            Appodeal.show(Appodeal.SKIPPABLE_VIDEO);
    }

    public void StartBanner()
    {
        if (Appodeal.isLoaded(Appodeal.BANNER_BOTTOM))
            Appodeal.show(Appodeal.BANNER_BOTTOM);
    }

    void Start()
    {
        isRecord = true;
        //Appodeal.hide(Appodeal.INTERSTITIAL);

        countGameover = PlayerPrefs.GetInt("CGO");

        //Получение первого подарка
        if (PlayerPrefs.GetInt("FirstGame") != 1)
        {
            firstMoney.SetActive(true);
            AddMoney(500);
            PlayerPrefs.SetInt("FirstGame", 1);
            buyAds.Play();
        }

        if (PlayerPrefs.GetInt("FirstStart") == 1)
        {
            isManager = false;
        }
        else
            isManager = true;
        if (gameObject.name == "GameManager")
            gM = 1;

        MaxMoney.text = PlayerPrefs.GetInt("Money").ToString();
        if(gameObject.name == "GameManager")
            record.text = record.text + PlayerPrefs.GetInt("Score").ToString();
        else
            record.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void AddMoney(int count)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + count);
        MaxMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }

	void Update () {
        if (gM == 1)
        {
            if (isManager)
            {
                scoreCount += 2;
                thisScore.text = scoreCount.ToString();
                //PlayerPrefs.SetInt("ScoreThis", scoreCount);
            }
        }
        else
            MaxMoney.text = PlayerPrefs.GetInt("Money").ToString();
        //Запись рекорда с учетом условия
        if ((PlayerPrefs.GetInt("Score")) < scoreCount && isRecord)
        {
            newRecord.SetActive(true);
            isRecord = false;
        }
    }
	public void Reviews()
	{
		//Ссылка на игру
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.mmko.taetled");
		PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5000);
		MaxMoney.text = PlayerPrefs.GetInt("Money").ToString();
		reviews.SetActive (false);
	} 
    public void StartScore()
    {
        isManager = true;
    }
    public void StopScore()
    {
		//Отзыв
		if (PlayerPrefs.GetInt ("Reviews") <= 10) {
			PlayerPrefs.SetInt ("Reviews", PlayerPrefs.GetInt ("Reviews") + 1);
			if (PlayerPrefs.GetInt ("Reviews") == 10)
				reviews.SetActive (true);
		}
        //StartBanner();
        countGameover++;
        if (PlayerPrefs.GetInt("CGO") <= 100)
            PlayerPrefs.SetInt("CGO", countGameover);
        else
            PlayerPrefs.SetInt("CGO", 0);
		/*rund = Random.Range(1, 3);
		switch (rund) {
		case 1:
			if (countGameover % 2 == 0)
				StartInterstitial ();
			break;
		case 2:
			if (countGameover % 2 == 0)
				StartCallBack ();
			break;
		}*/
		if (countGameover % 2 == 0)
			StartInterstitial ();


        isManager = false;
        PlayerPrefs.SetInt("ScoreThis", scoreCount);

        if ((PlayerPrefs.GetInt("Score")) < scoreCount)
        {
            PlayerPrefs.SetInt("Score", scoreCount);

            if(scoreCount >= 40000)
            {
                PlayerPrefs.SetInt("BuySave110", 1);
                PlayerPrefs.SetInt("buyCar", 10);
            }
            record.text = "Рекорд: " + (PlayerPrefs.GetInt("Score")).ToString();

            if (scoreCount / 1000 >= 1 && PlayerPrefs.GetInt("Award") < 1000 && scoreCount / 1000 <= 4)
            {
                goButtom.SetActive(true);
                award.text = "+" + (scoreCount / 1000 * 500);
                AddMoney(scoreCount / 1000 * 500);
                buyAds.Play();
                PlayerPrefs.SetInt("Award", 1000);
            }
                //Выдача денег за рекорд
                if (PlayerPrefs.GetInt("Award") / 5000 < scoreCount / 5000)
            {
                goButtom.SetActive(true);
                award.text = "+" + (scoreCount / 5000 * 500);
                AddMoney(scoreCount / 5000 * 500);
                buyAds.Play();
                PlayerPrefs.SetInt("Award", PlayerPrefs.GetInt("Award") + 5000);
            }

        }

        int topNow = (PlayerPrefs.GetInt("Score"));
        if (topNow > 6932)
        {
            int[] mas = new int[50] {954203, 702405, 390245, 299344, 250431, 250203, 220231, 210321, 203012, 202015, 180241, 160931, 150230, 130291, 115031, 100154, 90421, 90134, 80123, 70123, 65032, 50123, 40231, 40203, 350123, 29321,
            21321, 19324, 19300, 18032, 18021, 18018, 15923, 14321, 130321, 12343, 12221, 12003, 11234, 11121, 10432, 10021, 9321, 9003, 8503, 8203, 8012, 7402, 6932, topNow };

            //Сортировка массива
            for (int i = 0; i < 50 - 1; i++)
            {
                for (int j = 0; j < 50 - 1; j++)
                {
                    if (mas[j] < mas[j + 1])
                    {
                        int tmp = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = tmp;
                    }
                }
            }

            for (int i = 0; i < 50 - 1; i++)
            {
                if (mas[i] == topNow)
                {
                    int topPosition = i + 1;
                    top.text = "Вы на " + topPosition.ToString() + " месте" + "\r\n" + "в топе";
                    yourRecord.SetActive(true);
                }
            }


        }
    }
}
