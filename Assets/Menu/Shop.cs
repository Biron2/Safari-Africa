using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop : MonoBehaviour
{
    public Text gunInfoText, gunPlusText;
    public GameObject[] weapons;
    public RectTransform lockWeaponPic2, lockWeaponPic3;
    public GameObject unlockWeaponPic2, unlockWeaponPic3;
    public GameObject check1, check2, check3;
    public GameObject moneybarWeaponPic2, moneybarWeaponPic3;
    [SerializeField] private BuyController _BuyController;
    public AudioSource noMoneySource, btn_click, buy_sound;
    public float shakeAmount = 10f;
    public float shakeDuration = 0.1f;
    private string gun_text1, gun_text2, gun_text3, gun1plus, gun2plus, gun3plus;
    public Color green, red;
    private void Start()
    {
        _BuyController = GameObject.Find("BuyController").GetComponent<BuyController>();
        langInfo();
        if (YandexGame.savesData.isWeapon2unlocked == true)
        {
            lockWeaponPic2.gameObject.SetActive(false);
            unlockWeaponPic2.SetActive(true);
            moneybarWeaponPic2.SetActive(false);
        }
        if(YandexGame.savesData.isWeapon3unlocked == true)
        {
            lockWeaponPic3.gameObject.SetActive(false);
            unlockWeaponPic3.SetActive(true);
            moneybarWeaponPic3.SetActive(false);
        }
    }

    public void BuyWeapon1()
    {
        if(YandexGame.savesData.choosenWeapon != 1)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[0].SetActive(true);
            check1.SetActive(true);
            check2.SetActive(false);
            check3.SetActive(false);
            btn_click.Play();
            _BuyController.ChooseWeapon1();
            gunInfoText.text = gun_text1;
            gunPlusText.text = gun1plus;
            gunPlusText.color = red;
        }
    }
    public void BuyWeapon2()
    {
        if(YandexGame.savesData.isWeapon2unlocked == false)
        {
            if(YandexGame.savesData.money >= 2000)
            {
                buy_sound.Play();
                _BuyController.RemoveMoney(2000);
                check1.SetActive(false);
                check2.SetActive(true);
                check3.SetActive(false);
                lockWeaponPic2.gameObject.SetActive(false);
                unlockWeaponPic2.SetActive(true);
                moneybarWeaponPic2.SetActive(false);

                foreach(GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[1].SetActive(true);
                gunInfoText.text = gun_text2;
                gunPlusText.text = gun2plus;
                gunPlusText.color = green;
                _BuyController.ChooseWeapon2();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                Shake(lockWeaponPic2);
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 2)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[1].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(true);
                check3.SetActive(false);
                btn_click.Play();
                _BuyController.ChooseWeapon2();
                gunInfoText.text = gun_text2;
                gunPlusText.text = gun2plus;
                gunPlusText.color = green;
            }
        }
    }

    public void BuyWeapon3()
    {
        if (YandexGame.savesData.isWeapon3unlocked == false)
        {
            if (YandexGame.savesData.money >= 6500)
            {
                buy_sound.Play();
                _BuyController.RemoveMoney(6500);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(true);
                lockWeaponPic3.gameObject.SetActive(false);
                unlockWeaponPic3.SetActive(true);
                moneybarWeaponPic3.SetActive(false);

                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[2].SetActive(true);
                gunInfoText.text = gun_text3;
                gunPlusText.text = gun3plus;
                gunPlusText.color = green;
                _BuyController.ChooseWeapon3();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                Shake(lockWeaponPic3);
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 3)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[2].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(true);
                btn_click.Play();
                _BuyController.ChooseWeapon3();
                gunInfoText.text = gun_text3;
                gunPlusText.text = gun3plus;
                gunPlusText.color = green;
            }
        }
    }
    private void Shake(RectTransform rectTransform)
    {
        StartCoroutine(DoShake(rectTransform));
    }

    private IEnumerator DoShake(RectTransform rectTransform)
    {
        Vector3 initialPosition = rectTransform.localPosition;

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-0.25f, 0.25f) * shakeAmount;
            float y = Random.Range(-0.25f, 0.25f) * shakeAmount;

            rectTransform.localPosition = initialPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        rectTransform.localPosition = initialPosition;
    }
    public void langInfo()
    {
        if (YandexGame.lang == "ru")
        {
            gun_text1 = "Арбалет";
            gun_text2 = "Маузер 98k";
            gun_text3 = "Винтовка Мосина";

            gun1plus = "Очень медленная перезарядка";

            gun2plus = "Быстрая перезарядка";

            gun3plus = "Очень быстрая перезарядка";
        }
        else if (YandexGame.lang == "en")
        {
            gun_text1 = "Crossbow";
            gun_text2 = "Mauser 98k";
            gun_text3 = "Mosin rifle";

            gun1plus = "Very slow recharge";

            gun2plus = "Fast recharge";

            gun3plus = "Very fast recharge";
        }
        else if (YandexGame.lang == "tr")
        {
            gun_text1 = "Arbalet";
            gun_text2 = "Mauser 98k";
            gun_text3 = "Mosin tüfeği";

            gun1plus = "Çok yavaş şarj oluyor";

            gun2plus = "Hızlı şarj";

            gun3plus = "Çok hızlı şarj";
        }
        if (YandexGame.savesData.choosenWeapon == 1)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[0].SetActive(true);
            check1.SetActive(true);
            check2.SetActive(false);
            check3.SetActive(false);
            gunInfoText.text = gun_text1;
            gunPlusText.text = gun1plus;
            gunPlusText.color = red;
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[1].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(true);
            check3.SetActive(false);
            gunInfoText.text = gun_text2;
            gunPlusText.text = gun2plus;
            gunPlusText.color = green;
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[2].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(false);
            check3.SetActive(true);
            gunInfoText.text = gun_text3;
            gunPlusText.text = gun3plus;
            gunPlusText.color = green;
        }
    }
}
