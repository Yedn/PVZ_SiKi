using UnityEngine;
using UnityEngine.UI;

enum CardState
{
    Cooling,
    WaitingSun,
    Ready
}

public class Card : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CardState cardState = CardState.Cooling;
    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;
    [SerializeField]
    private float coolTime = 2.0f;
    private float coolTimer = 0.0f;

    [SerializeField]
    private int needSunPoint = 50;
    //3 state:
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
        }

    }
    private void CoolingUpdate()
    {
        coolTimer += Time.deltaTime;
        cardMask.fillAmount = (coolTime - coolTimer) / coolTime;
        if (coolTimer >= coolTime)
        {
            TranslateToWaitingSun();
        }
    }

    private void WaitingSunUpdate()
    {
        if (needSunPoint <= SunManager.Instance.SunPoint)
        {
            TranslateToReady();
        }
    }

    private void ReadyUpdate()
    {
        if (needSunPoint > SunManager.Instance.SunPoint)
        {
            TranslateToWaitingSun();
        }

    }

    private void TranslateToWaitingSun()
    {
        cardState = CardState.WaitingSun;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    }

    private void TranslateToReady()
    {
        cardState = CardState.Ready;
        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }

    private void TranslateToCooling()
    {
        cardState = CardState.Cooling;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
        coolTimer = 0.0f;
    }

    public void OnClick()
    {
        if (needSunPoint > SunManager.Instance.SunPoint)
        {
            return;
        }
        //TODO: ÖÖÖ²

        //-testing code-
        SunManager.Instance.SubSun(needSunPoint);
        //-----end------

        TranslateToCooling();
    }
}
