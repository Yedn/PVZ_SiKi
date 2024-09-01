using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public PrepareUI prepareUI;
    public CardListUI cardListUI;

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
        Camera.main.transform.DOPath(new Vector3[] {currentPosition,new Vector3(5,0,-10),currentPosition},4.0f,PathType.Linear).OnComplete(ShowPrepareUI);
    }

    void ShowPrepareUI()
    {
        prepareUI.Show(OnPrepareUIComplete);
    }
    void OnPrepareUIComplete()
    {
        SunManager.Instance.StartProduct();
        ZombieManger.Instance.StartSpawn();
        cardListUI.ShowCardListUI();

    }

}
