using TMPro;
using UnityEngine;


public class SunManager : MonoBehaviour
{
    public static SunManager Instance { get; private set; }

    [SerializeField]
    private int sunPoint;
    public int SunPoint
    {
        get
        {
            return sunPoint;
        }
    }

    public TextMeshProUGUI sunPointText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateSunPointText();
    }

    public void UpdateSunPointText()
    {
        sunPointText.text = SunPoint.ToString();
    }

    public void SubSun(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }
}
