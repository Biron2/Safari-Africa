using UnityEngine;
using UnityEngine.UI;
using YG;

public class RanksController : MonoBehaviour
{
    public Text rankText;
    private string rank1, rank2, rank3, rank4, rank5, rank6, rank7;
    void Start()
    {
        langRanks();
    }
    public void langRanks()
    {
        if (YandexGame.lang == "ru")
        {
            rank1 = "Новичок";
            rank2 = "Стрелок";
            rank3 = "Зверолов";
            rank4 = "Следопыт";
            rank5 = "Охотник";
            rank6 = "Траппер";
            rank7 = "Африканер";
        }
        else if (YandexGame.lang == "en")
        {
            rank1 = "Newcomer";
            rank2 = "Shooter";
            rank3 = "Beastmaster";
            rank4 = "Pathfinder";
            rank5 = "Hunter";
            rank6 = "Trapper";
            rank7 = "Afrikaner";
        }
        else if (YandexGame.lang == "tr")
        {
            rank1 = "Yeni Gelen";
            rank2 = "Nişancı";
            rank3 = "Beastmaster";
            rank4 = "Pathfinder";
            rank5 = "Avcı";
            rank6 = "Tuzakçı";
            rank7 = "Afrikaner";
        }

        int level = YandexGame.savesData.level;

        switch (level)
        {
            case var _ when level >= 25:
                rankText.text = rank7;
                break;
            case var _ when level >= 20:
                rankText.text = rank6;
                break;
            case var _ when level >= 15:
                rankText.text = rank5;
                break;
            case var _ when level >= 10:
                rankText.text = rank4;
                break;
            case var _ when level >= 5:
                rankText.text = rank3;
                break;
            case var _ when level >= 3:
                rankText.text = rank2;
                break;
            default:
                rankText.text = rank1;
                break;
        }
    }
}
