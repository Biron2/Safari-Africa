using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;
public class game_controller : MonoBehaviour
{
    public AudioSource tarakanSpawned, x2_buysound;
    public randomclickgame _Randomclickgame;
    [SerializeField] private GameObject winWindow, rewardBtn, pauseWindow, weapon_controller;
    [SerializeField] private GameObject wp1, wp2, wp3, wp1Ammo, wp2Ammo, wp3Ammo;
    [SerializeField] private Text earnText, levelWonText, ratСounter;
    public AudioSource game_music;
    public bool allowPause = true;
    [SerializeField] private GameObject[] starsObj;
    int earn_money;
    public int ratMustBeKilled;
    [SerializeField] private Image background, grass;
    [SerializeField] private Sprite[] background_sprites;
    private void Awake()
    {
        switch (YandexGame.savesData.currentLevel)
        {
            case var _ when YandexGame.savesData.currentLevel >= 21:
                background.sprite = background_sprites[2];
                grass.sprite = background_sprites[5];
                break;
            case var _ when YandexGame.savesData.currentLevel >= 11:
                background.sprite = background_sprites[1];
                grass.sprite = background_sprites[4];
                break;
            case var _ when YandexGame.savesData.currentLevel >= 1:
                background.sprite = background_sprites[0];
                grass.sprite = background_sprites[3];
                break;
        }
    }
    private void Start()
    {
        if (YandexGame.savesData.choosenWeapon == 1)
        {
            wp1.SetActive(true);
            wp1Ammo.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            wp2.SetActive(true);
            wp2Ammo.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            wp3.SetActive(true);
            wp3Ammo.SetActive(true);
        }


        switch (YandexGame.savesData.currentLevel)
        {
            case 1:
                ratMustBeKilled = 3;
                earn_money = Random.Range(25, 50);
                break;
            case 2:
                ratMustBeKilled = 3;
                earn_money = Random.Range(50, 75);
                break;
            case 3:
                ratMustBeKilled = 5;
                earn_money = Random.Range(75, 100);
                break;
            case 4:
                ratMustBeKilled = 6;
                earn_money = Random.Range(100, 125);
                break;
            case 5:
                ratMustBeKilled = 6;
                earn_money = Random.Range(125, 150);
                break;
            case 6:
                ratMustBeKilled = 7;
                earn_money = Random.Range(150, 175);
                break;
            case 7:
                ratMustBeKilled = 5;
                earn_money = Random.Range(175, 200);
                break;
            case 8:
                ratMustBeKilled = 6;
                earn_money = Random.Range(200, 225);
                break;
            case 9:
                ratMustBeKilled = 6;
                earn_money = Random.Range(225, 250);
                break;
            case 10:
                ratMustBeKilled = 6;
                earn_money = Random.Range(250, 275);
                break;
            case 11:
                ratMustBeKilled = 4;
                earn_money = Random.Range(275, 300);
                break;
            case 12:
                ratMustBeKilled = 4;
                earn_money = Random.Range(300, 325);
                break;
            case 13:
                ratMustBeKilled = 6;
                earn_money = Random.Range(325, 350);
                break;
            case 14:
                ratMustBeKilled = 3;
                earn_money = Random.Range(350, 375);
                break;
            case 15:
                ratMustBeKilled = 5;
                earn_money = Random.Range(375, 400);
                break;
            case 16:
                ratMustBeKilled = 5;
                earn_money = Random.Range(400, 425);
                break;
            case 17:
                ratMustBeKilled = 9;
                earn_money = Random.Range(425, 450);
                break;
            case 18:
                ratMustBeKilled = 10;
                earn_money = Random.Range(450, 475);
                break;
            case 19:
                ratMustBeKilled = 10;
                earn_money = Random.Range(475, 500);
                break;
            case 20:
                ratMustBeKilled = 6;
                earn_money = Random.Range(500, 525);
                break;
            case 21:
                ratMustBeKilled = 10;
                earn_money = Random.Range(525, 550);
                break;
            case 22:
                ratMustBeKilled = 10;
                earn_money = Random.Range(550, 575);
                break;
            case 23:
                ratMustBeKilled = 11;
                earn_money = Random.Range(575, 600);
                break;
            case 24:
                ratMustBeKilled = 5;
                earn_money = Random.Range(600, 625);
                break;
            case 25:
                ratMustBeKilled = 14;
                earn_money = Random.Range(625, 650);
                break;
            case 26:
                ratMustBeKilled = 10;
                earn_money = Random.Range(650, 675);
                break;
            case 27:
                ratMustBeKilled = 13;
                earn_money = Random.Range(675, 700);
                break;
            case 28:
                ratMustBeKilled = 14;
                earn_money = Random.Range(700, 725);
                break;
            case 29:
                ratMustBeKilled = 16;
                earn_money = Random.Range(725, 750);
                break;
            case 30:
                ratMustBeKilled = 14;
                earn_money = Random.Range(750, 775);
                break;
            default:
                ratMustBeKilled = 3;
                earn_money = Random.Range(25, 50);
                break;
        }
        RatCounterUpdate();
    }
    public void RatCounterUpdate()
    {
        ratСounter.text = _Randomclickgame.shotedTarakan + "/" + ratMustBeKilled.ToString();
    }
    public void WinMethod()
    {
        if (_Randomclickgame.shotedTarakan >= ratMustBeKilled)
        {
            int stars = 0;

            switch (_Randomclickgame.bullets)
            {
                case var _ when _Randomclickgame.bullets >= 2:
                    stars = 3;
                    break;
                case var _ when _Randomclickgame.bullets >= 1:
                    stars = 2;
                    break;
                case var _ when _Randomclickgame.bullets >= 0:
                    stars = 1;
                    break;
            }

            switch (stars)
            {
                case 1:
                    starsObj[1].SetActive(true);
                    break;
                case 2:
                    starsObj[0].SetActive(true);
                    starsObj[2].SetActive(true);
                    break;
                case 3:
                    starsObj[0].SetActive(true);
                    starsObj[1].SetActive(true);
                    starsObj[2].SetActive(true);
                    break;
            }

            switch (YandexGame.savesData.currentLevel)
            {
                case 1:
                    if (YandexGame.savesData.level_stars1 < stars)
                        YandexGame.savesData.level_stars1 = stars;
                    break;
                case 2:
                    if (YandexGame.savesData.level_stars2 < stars)
                        YandexGame.savesData.level_stars2 = stars;
                    break;
                case 3:
                    if (YandexGame.savesData.level_stars3 < stars)
                        YandexGame.savesData.level_stars3 = stars;
                    break;
                case 4:
                    if (YandexGame.savesData.level_stars4 < stars)
                        YandexGame.savesData.level_stars4 = stars;
                    break;
                case 5:
                    if (YandexGame.savesData.level_stars5 < stars)
                        YandexGame.savesData.level_stars5 = stars;
                    break;
                case 6:
                    if (YandexGame.savesData.level_stars6 < stars)
                        YandexGame.savesData.level_stars6 = stars;
                    break;
                case 7:
                    if (YandexGame.savesData.level_stars7 < stars)
                        YandexGame.savesData.level_stars7 = stars;
                    break;
                case 8:
                    if (YandexGame.savesData.level_stars8 < stars)
                        YandexGame.savesData.level_stars8 = stars;
                    break;
                case 9:
                    if (YandexGame.savesData.level_stars9 < stars)
                        YandexGame.savesData.level_stars9 = stars;
                    break;
                case 10:
                    if (YandexGame.savesData.level_stars10 < stars)
                        YandexGame.savesData.level_stars10 = stars;
                    break;
                case 11:
                    if (YandexGame.savesData.level_stars11 < stars)
                        YandexGame.savesData.level_stars11 = stars;
                    break;
                case 12:
                    if (YandexGame.savesData.level_stars12 < stars)
                        YandexGame.savesData.level_stars12 = stars;
                    break;
                case 13:
                    if (YandexGame.savesData.level_stars13 < stars)
                        YandexGame.savesData.level_stars13 = stars;
                    break;
                case 14:
                    if (YandexGame.savesData.level_stars14 < stars)
                        YandexGame.savesData.level_stars14 = stars;
                    break;
                case 15:
                    if (YandexGame.savesData.level_stars15 < stars)
                        YandexGame.savesData.level_stars15 = stars;
                    break;
                case 16:
                    if (YandexGame.savesData.level_stars16 < stars)
                        YandexGame.savesData.level_stars16 = stars;
                    break;
                case 17:
                    if (YandexGame.savesData.level_stars17 < stars)
                        YandexGame.savesData.level_stars17 = stars;
                    break;
                case 18:
                    if (YandexGame.savesData.level_stars18 < stars)
                        YandexGame.savesData.level_stars18 = stars;
                    break;
                case 19:
                    if (YandexGame.savesData.level_stars19 < stars)
                        YandexGame.savesData.level_stars19 = stars;
                    break;
                case 20:
                    if (YandexGame.savesData.level_stars20 < stars)
                        YandexGame.savesData.level_stars20 = stars;
                    break;
                case 21:
                    if (YandexGame.savesData.level_stars21 < stars)
                        YandexGame.savesData.level_stars21 = stars;
                    break;
                case 22:
                    if (YandexGame.savesData.level_stars22 < stars)
                        YandexGame.savesData.level_stars22 = stars;
                    break;
                case 23:
                    if (YandexGame.savesData.level_stars23 < stars)
                        YandexGame.savesData.level_stars23 = stars;
                    break;
                case 24:
                    if (YandexGame.savesData.level_stars24 < stars)
                        YandexGame.savesData.level_stars24 = stars;
                    break;
                case 25:
                    if (YandexGame.savesData.level_stars25 < stars)
                        YandexGame.savesData.level_stars25 = stars;
                    break;
                case 26:
                    if (YandexGame.savesData.level_stars26 < stars)
                        YandexGame.savesData.level_stars26 = stars;
                    break;
                case 27:
                    if (YandexGame.savesData.level_stars27 < stars)
                        YandexGame.savesData.level_stars27 = stars;
                    break;
                case 28:
                    if (YandexGame.savesData.level_stars28 < stars)
                        YandexGame.savesData.level_stars28 = stars;
                    break;
                case 29:
                    if (YandexGame.savesData.level_stars29 < stars)
                        YandexGame.savesData.level_stars29 = stars;
                    break;
                case 30:
                    if (YandexGame.savesData.level_stars30 < stars)
                        YandexGame.savesData.level_stars30 = stars;
                    break;
            }
            game_music.Stop();
            allowPause = false;
            winWindow.SetActive(true);
            wp1.SetActive(false);
            wp2.SetActive(false);
            wp3.SetActive(false);
            weapon_controller.GetComponent<WeaponController>().enabled = false;
            if (YandexGame.savesData.level != 30)
            {
                if (YandexGame.savesData.currentLevel == YandexGame.savesData.level)
                {
                    YandexGame.savesData.level++;
                    YandexGame.NewLeaderboardScores("achievedlevelslb", YandexGame.savesData.currentLevel);
                }
            }

            if (YandexGame.lang == "ru")
            {
                earnText.text = "Добыча: " + earn_money.ToString();
                levelWonText.text = "Уровень " + YandexGame.savesData.currentLevel + " пройден!";
            }
            else if (YandexGame.lang == "en")
            {
                earnText.text = "Yield: " + earn_money.ToString();
                levelWonText.text = "Level: " + YandexGame.savesData.currentLevel + " completed!";
            }
            else if (YandexGame.lang == "tr")
            {
                earnText.text = "Verim: " + earn_money.ToString();
                levelWonText.text = "Seviye: " + YandexGame.savesData.currentLevel + " geçti!";
            }
            YandexGame.savesData.money += earn_money;
            YandexGame.SaveProgress();
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
        if (id == 3)
        {
            x2_buysound.Play();
            YandexGame.savesData.money += earn_money;
            if (YandexGame.lang == "ru")
            {
                earnText.text = "Добыча: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "en")
            {
                earnText.text = "Yield: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                earnText.text = "Verim: " + (earn_money *= 2).ToString();
            }
            rewardBtn.SetActive(false);
            YandexGame.SaveProgress();
        }
        if (id == 4)
        {
            x2_buysound.Play();
            YandexGame.savesData.money += earn_money;
            if (YandexGame.lang == "ru")
            {
                earnText.text = "Добыча: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "en")
            {
                earnText.text = "Yield: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                earnText.text = "Verim: " + (earn_money *= 2).ToString();
            }
            rewardBtn.SetActive(false);
            YandexGame.SaveProgress();
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        weapon_controller.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseWindow.SetActive(false);
    }
}
