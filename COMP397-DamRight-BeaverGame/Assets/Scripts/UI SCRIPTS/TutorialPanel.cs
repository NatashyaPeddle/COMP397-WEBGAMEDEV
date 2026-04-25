using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Start()
    {
        tutorialPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
