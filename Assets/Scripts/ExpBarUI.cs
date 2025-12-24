using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBarUI : MonoBehaviour
{
    public Image expFill;
    public TMP_Text levelText;
    public TMP_Text expValueText;

    void Update()
    {
        if (LevelManager.Instance == null) return;

        float fill =
            (float)LevelManager.Instance.CurrentExp /
            LevelManager.Instance.ExpToNextLevel;

        expFill.fillAmount = fill;

        levelText.text = "" + LevelManager.Instance.CurrentLevel;
        expValueText.text =
            LevelManager.Instance.CurrentExp + " / " +
            LevelManager.Instance.ExpToNextLevel;
    }
}
