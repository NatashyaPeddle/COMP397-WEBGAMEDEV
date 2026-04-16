using TMPro;
using UnityEngine;
using System.Collections;

public class AchievementUI : MonoBehaviour
{

    [SerializeField] private GameObject AchievementUIPanel;
    [SerializeField] private TextMeshProUGUI AchievementText;
    [SerializeField] private float duration = 2.5f;

    public void ShowAchievement (string title, string description)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(title, description));
    }

    private IEnumerator ShowRoutine(string title, string description)
    {
        AchievementUIPanel.SetActive(true);
        AchievementText.text = "<b>" + title + "</b>\n" + description;
        yield return new WaitForSeconds(duration);
        AchievementUIPanel.SetActive(false);
    }

}