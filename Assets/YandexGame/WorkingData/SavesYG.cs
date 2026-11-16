
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 0;
        public int level = 1;
        public int currentLevel;

        public int level_stars1 = 0;
        public int level_stars2 = 0;
        public int level_stars3 = 0;
        public int level_stars4 = 0;
        public int level_stars5 = 0;
        public int level_stars6 = 0;
        public int level_stars7 = 0;
        public int level_stars8 = 0;
        public int level_stars9 = 0;
        public int level_stars10 = 0;
        public int level_stars11 = 0;
        public int level_stars12 = 0;
        public int level_stars13 = 0;
        public int level_stars14 = 0;
        public int level_stars15 = 0;
        public int level_stars16 = 0;
        public int level_stars17 = 0;
        public int level_stars18 = 0;
        public int level_stars19 = 0;
        public int level_stars20 = 0;
        public int level_stars21 = 0;
        public int level_stars22 = 0;
        public int level_stars23 = 0;
        public int level_stars24 = 0;
        public int level_stars25 = 0;
        public int level_stars26 = 0;
        public int level_stars27 = 0;
        public int level_stars28 = 0;
        public int level_stars29 = 0;
        public int level_stars30 = 0;

        public bool isWeapon2unlocked = false;
        public bool isWeapon3unlocked = false;
        public int choosenWeapon = 1;

        public bool is_sounds_changed = false;
        public float sfx = 1;
        public float music = 1;

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
        }
    }
}
