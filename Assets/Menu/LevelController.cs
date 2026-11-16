using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int mCurrentLevel = 1;
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => LoadGameByLevelButton());
        GameObject _gameObject = transform.Find("lock").gameObject;
        for (int i = 1; i <= 30; i++)
        {
            string levelName = "level" + i.ToString();
            if (gameObject.name.Equals(levelName) && YandexGame.savesData.level >= i)
            {
                button.interactable = true;
                _gameObject.SetActive(false);
                break; // Для остановки цикла после первого срабатывания условия
            }
        }
        GameObject _starsCont = transform.Find("stars_container").gameObject;
        GameObject star1 = _starsCont.transform.Find("star1").gameObject;
        GameObject star2 = _starsCont.transform.Find("star2").gameObject;
        GameObject star3 = _starsCont.transform.Find("star3").gameObject;

        int totalLevels = 30;
        int[] levels = new int[totalLevels];
        GameObject[] starsArray = new GameObject[3]; // массив для хранения ссылок на объекты звезд

        starsArray[0] = star1;
        starsArray[1] = star2;
        starsArray[2] = star3;

        for (int i = 0; i < totalLevels; i++)
        {
            if (gameObject.name.Equals("level" + (i + 1)))
            {
                int stars = (int)YandexGame.savesData.GetType().GetField("level_stars" + (i + 1)).GetValue(YandexGame.savesData);

                if (stars == 1)
                {
                    starsArray[1].SetActive(true);
                }
                else if (stars == 2)
                {
                    starsArray[0].SetActive(true);
                    starsArray[2].SetActive(true);
                }
                else if (stars == 3)
                {
                    starsArray[0].SetActive(true);
                    starsArray[1].SetActive(true);
                    starsArray[2].SetActive(true);
                }
            }
        }
    }
    private void LoadGameByLevelButton()
    {
        YandexGame.savesData.currentLevel = mCurrentLevel;
        SceneManager.LoadScene("Game");
    }
}
