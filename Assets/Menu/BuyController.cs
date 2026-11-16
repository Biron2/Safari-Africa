using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;
using System.Collections;

public class BuyController : MonoBehaviour
{
    public Text textMoney;
    public AudioSource x2sound;

    public Color blinkColor = Color.red;
    public float blinkDuration = 0.2f;

    private Color originalColor;
    private bool isBlinking = false;
    private void Start()
    {
        originalColor = textMoney.color;
        if (YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }
    }
    public void Start_Game()
    {
        SceneManager.LoadScene("Game");
    }
    void Rewarded(int id)
    {
        if (id == 1)
        {
            AddMoney(375);
            MySave();
            LoadSaveCloud(); // Update UI after saving
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void AddMoney(int money)
    {
        x2sound.Play();
        YandexGame.savesData.money += money;
        textMoney.text = YandexGame.savesData.money.ToString();
        MySave();
    }
    public void ChooseWeapon1()
    {
        YandexGame.savesData.choosenWeapon = 1;
        MySave();
    }
    public void ChooseWeapon2()
    {
        YandexGame.savesData.choosenWeapon = 2;
        MySave();
    }
    public void ChooseWeapon3()
    {
        YandexGame.savesData.choosenWeapon = 3;
        MySave();
    }

    public void RemoveMoney(int price)
    {
        if(price == 2000)
        {
            YandexGame.savesData.isWeapon2unlocked = true;
        }
        else if(price == 6500)
        {
            YandexGame.savesData.isWeapon3unlocked = true;
        }
        YandexGame.savesData.money -= price;
        textMoney.text = YandexGame.savesData.money.ToString();
        MySave();
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveCloud;
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveCloud;
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    public void LoadSaveCloud()
    {
        textMoney.text = YandexGame.savesData.money.ToString();
    }
    public void MySave()
    {
        YandexGame.SaveProgress();
    }
    public void StartBlinkingNoMoney()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkText());
        }
    }

    IEnumerator BlinkText()
    {
        isBlinking = true;
        float time = 0f;

        while (time < blinkDuration)
        {
            textMoney.color = (textMoney.color == originalColor) ? blinkColor : originalColor;
            time += Time.deltaTime;
            yield return null;
        }

        textMoney.color = originalColor;
        isBlinking = false;
    }
}
