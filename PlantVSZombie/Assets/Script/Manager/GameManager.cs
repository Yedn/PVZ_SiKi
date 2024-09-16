using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public PrepareUI prepareUI;
    public CardListUI cardListUI;
    public FailUI failUI;
    public WinUI winUI;

    private bool isGameEnd = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameStart();
    }
    void GameStart()
    {
        Vector3 currentPosition=Camera.main.transform.position;
        Camera.main.transform.DOPath(new Vector3[] {currentPosition,new Vector3(5,0,-10),currentPosition},4.0f,PathType.Linear).OnComplete(OnCameraMoveComplete);
    }
    public void GameEndFail()
    {
        if (!isGameEnd)
        {
            isGameEnd = true;
            failUI.Show();
            ZombieManger.Instance.Pause();
            cardListUI.DisableCardList();
            SunManager.Instance.StopProduct();
            AudioManager.instance.PlayClip(Config.lose_music);
        }
        else
        {
            return;
        }
    }

    public void GameEndSuccess()
    {
        if (isGameEnd == true) return;
        isGameEnd = true;
        winUI.Show();
        cardListUI.DisableCardList();
        SunManager.Instance.StopProduct();
        AudioManager.instance.PlayClip(Config.win_music);
    }
    void OnCameraMoveComplete()
    {
        prepareUI.Show(OnPrepareUIComplete);
    }
    void OnPrepareUIComplete()
    {
        SunManager.Instance.StartProduct();
        ZombieManger.Instance.StartSpawn();
        cardListUI.ShowCardListUI();
        AudioManager.instance.PlayBgm(Config.bgm1);
    }

}
