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

    [Header("Naturally produce sun")]
    public float produceTime = 10.0f;
    private float produceTimer = 0.0f;
    public GameObject SunPrefab;
    private bool isStartProduct = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateSunPointText();
        CalcSunPointTextPosition();

        //testCode
        StartProduct();
    }
    private void Update()
    {
        if (isStartProduct) 
        {
            ProduceSun();
        }
        
    }

    public void StartProduct()
    {
        isStartProduct = true;
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
    void ProduceSun()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer >= produceTime)
        {
            produceTimer = 0.0f;
            Vector3 position = new Vector3(Random.Range(-4, 6.2f), 6.1f, -1);
            GameObject go = GameObject.Instantiate(SunPrefab, position, Quaternion.identity);
            position.y = Random.Range(-3.8f, 2.8f);
            go.GetComponent<Sun>().LinearTo(position);
        }
    }

}
