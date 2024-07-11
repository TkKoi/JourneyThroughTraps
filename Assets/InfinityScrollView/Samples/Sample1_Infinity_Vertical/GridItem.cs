using UnityEngine;
using OneP.InfinityScrollView;
using TMPro;
using StarsSystem;
using UnityEngine.UI;
using TombOfTheMaskClone;
using Vampire;

public class GridItem : InfinityBaseItem
{
    [SerializeField] TextMeshProUGUI LevelNumbertext;
    [SerializeField] UISetStars uISetStars;
    [SerializeField] UILevelUnlock uILevelUnlock;
    [SerializeField] int energyPriece;
    [SerializeField] Button levelButton;

    private void Start()
    {
        // Подписываемся на событие клика кнопки и вызываем метод LoadLevel
        levelButton.onClick.AddListener(() => LoadLevel(Index + 1));
        //uISetStars.SetLevel(Index + 1);
    }

    public override void Reload(int _index)
    {
        base.Reload(_index);
        int LevelNumber = Index + 1;
        LevelNumbertext.text = LevelNumber.ToString();
        uILevelUnlock.SetCurrentButtonID(Index);
        uISetStars.SetLevel(LevelNumber);
    }

    private void LoadLevel(int level)
    {
        // Загрузка уровня с использованием указанного уровня
        ShowLoadingPanel.LoadLevel("Level_" + level);
    }
}
