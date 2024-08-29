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
    private Vector3 sunPointTextPosition;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateSunPointText();
        CalcSunPointTextPosition();
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
    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPointText();
    }

    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }
    private void CalcSunPointTextPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        position.z = 0;
        sunPointTextPosition = position;
    }
}
