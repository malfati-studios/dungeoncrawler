using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public enum BarType
    {
        HP,
        MP
    }

    [SerializeField] private Image fill = null;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private BarType type;

    public void UpdateBar(int max, int current)
    {
        fill.fillAmount = (float) current / (float) max;
        switch (type)
        {
            case BarType.HP:
                text.text = "HP " + current + "/" + max;
                break;
            case BarType.MP:
                text.text = "MP " + current + "/" + max;
                break;
        }
    }
}