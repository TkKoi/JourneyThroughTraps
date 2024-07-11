using UnityEngine;
using TMPro;
using System.Collections;

public class LoadingText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro; // Ссылка на компонент TextMeshProUGUI
    private string[] loadingTexts = { "Loading...", "Loading..", "Loading.", "Loading", "Loading..." }; // Массив текстов
    private int currentTextIndex = 0; // Индекс текущего текста

    void Start()
    {
        StartCoroutine(UpdateLoadingText());
    }

    IEnumerator UpdateLoadingText()
    {
        while (true)
        {
            textMeshPro.text = loadingTexts[currentTextIndex]; // Обновляем текст
            currentTextIndex = (currentTextIndex + 1) % loadingTexts.Length; // Переход к следующему тексту
            yield return new WaitForSeconds(0.5f); // Ожидание 0.5 секунд перед следующим обновлением
        }
    }
}

