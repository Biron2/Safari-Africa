using UnityEngine;
using UnityEngine.UI;
using YG;
public class randomclickgame : MonoBehaviour
{
    [SerializeField] private game_controller mRndclckgm;
    public AudioSource x2_buysound;
    [SerializeField] private GameObject loseWindow, pauseWindow, rewardBtn, rewardBtnBullet, weapon_controller;
    public bool allowStartAgain = true, isRewardBulletShowen = false;
    public int shotedTarakan = 0;
    public AudioSource game_music;
    [SerializeField] private Transform bullets_parent;

    [SerializeField] private GameObject[] allAnimalGroups;
    public int bullets = 4, loseEarnMoney;
    public Text bullets_text, loseEarnMoneyText;
    private bool onceActionForZeroBulletsMethod = false;
    private void Start()
    {
        switch (YandexGame.savesData.currentLevel)
        {
            case 1:
                bullets = 4;
                allAnimalGroups[0].SetActive(true);
                break;
            case 2:
                bullets = 3;
                allAnimalGroups[1].SetActive(true);
                break;
            case 3:
                bullets = 5;
                allAnimalGroups[2].SetActive(true);
                break;
            case 4:
                bullets = 6;
                allAnimalGroups[3].SetActive(true);
                break;
            case 5:
                bullets = 5;
                allAnimalGroups[4].SetActive(true);
                break;
            case 6:
                bullets = 6;
                allAnimalGroups[5].SetActive(true);
                break;
            case 7:
                bullets = 5;
                allAnimalGroups[6].SetActive(true);
                break;
            case 8:
                bullets = 6;
                allAnimalGroups[7].SetActive(true);
                break;
            case 9:
                bullets = 5;
                allAnimalGroups[8].SetActive(true);
                break;
            case 10:
                bullets = 5;
                allAnimalGroups[9].SetActive(true);
                break;
            case 11:
                bullets = 4;
                allAnimalGroups[10].SetActive(true);
                break;
            case 12:
                bullets = 3;
                allAnimalGroups[11].SetActive(true);
                break;
            case 13:
                bullets = 4;
                allAnimalGroups[12].SetActive(true);
                break;
            case 14:
                bullets = 3;
                allAnimalGroups[13].SetActive(true);
                break;
            case 15:
                bullets = 4;
                allAnimalGroups[14].SetActive(true);
                break;
            case 16:
                bullets = 4;
                allAnimalGroups[15].SetActive(true);
                break;
            case 17:
                bullets = 8;
                allAnimalGroups[16].SetActive(true);
                break;
            case 18:
                bullets = 8;
                allAnimalGroups[17].SetActive(true);
                break;
            case 19:
                bullets = 8;
                allAnimalGroups[18].SetActive(true);
                break;
            case 20:
                bullets = 4;
                allAnimalGroups[19].SetActive(true);
                break;
            case 21:
                bullets = 10;
                allAnimalGroups[20].SetActive(true);
                break;
            case 22:
                bullets = 8;
                allAnimalGroups[21].SetActive(true);
                break;
            case 23:
                bullets = 10;
                allAnimalGroups[22].SetActive(true);
                break;
            case 24:
                bullets = 5;
                allAnimalGroups[23].SetActive(true);
                break;
            case 25:
                bullets = 12;
                allAnimalGroups[24].SetActive(true);
                break;
            case 26:
                bullets = 8;
                allAnimalGroups[25].SetActive(true);
                break;
            case 27:
                bullets = 11;
                allAnimalGroups[26].SetActive(true);
                break;
            case 28:
                bullets = 8;
                allAnimalGroups[27].SetActive(true);
                break;
            case 29:
                bullets = 14;
                allAnimalGroups[28].SetActive(true);
                break;
            case 30:
                bullets = 7;
                allAnimalGroups[29].SetActive(true);
                break;
        }
        UpdateBulletsText();
    }
    public void UpdateBulletsText()
    {
        bullets_text.text = bullets.ToString();

        if (bullets == 3)
        {
            bullets_text.color = Color.yellow;
        }
        else if (bullets == 2)
        {
            if (isRewardBulletShowen == false)
            {
                rewardBtnBullet.SetActive(true);
            }
            bullets_text.color = new Color32(255, 165, 0, 255); //#orange
        }
        else if (bullets == 1)
        {
            bullets_text.color = Color.red;
        }
        else
        {
            bullets_text.color = Color.white;
        }
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    void Rewarded(int id)
    {
        if (id == 4)
        {
            x2_buysound.Play();
            YandexGame.savesData.money += loseEarnMoney;
            if (YandexGame.lang == "ru")
            {
                loseEarnMoneyText.text = "Добыча: " + (loseEarnMoney *= 2).ToString();
            }
            else if (YandexGame.lang == "en")
            {
                loseEarnMoneyText.text = "Yield: " + (loseEarnMoney *= 2).ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                loseEarnMoneyText.text = "Verim: " + (loseEarnMoney *= 2).ToString();
            }
            rewardBtn.SetActive(false);
            YandexGame.SaveProgress();
        }
        if (id == 5)
        {
            isRewardBulletShowen = true;
            rewardBtnBullet.SetActive(false);
            x2_buysound.Play();
            bullets += 2;
            UpdateBulletsText();
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseW();
        }
        if(bullets_parent != null)
        {
            if (bullets <= 0 && bullets_parent.childCount == 0 && onceActionForZeroBulletsMethod == false)
            {
                onceActionForZeroBulletsMethod = true;
                ZeroBullets();
            }
        }
    }
    public void PauseW()
    {
        if (mRndclckgm.allowPause == true)
        {
            weapon_controller.SetActive(false);
            AudioListener.pause = true;
            Time.timeScale = 0;
            pauseWindow.SetActive(true);
        }
    }
    public void ZeroBullets()
    {
        if (shotedTarakan != mRndclckgm.ratMustBeKilled)
        {
            game_music.Stop();
            mRndclckgm.allowPause = false;
            allAnimalGroups[30].SetActive(false);
            allAnimalGroups[31].SetActive(false);
            allAnimalGroups[32].SetActive(false);
            weapon_controller.GetComponent<WeaponController>().enabled = false;

            loseEarnMoney = Random.Range(5 + YandexGame.savesData.currentLevel, 25 + YandexGame.savesData.currentLevel);
            if (YandexGame.lang == "ru")
            {
                loseEarnMoneyText.text = "Добыча: " + loseEarnMoney.ToString();
            }
            else if (YandexGame.lang == "en")
            {
                loseEarnMoneyText.text = "Yield: " + loseEarnMoney.ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                loseEarnMoneyText.text = "Verim: " + loseEarnMoney.ToString();
            }
            loseWindow.SetActive(true);
            YandexGame.SaveProgress();
        }
    }
}
