using System;
using UnityEngine;

public class PrepareUI : MonoBehaviour
{
    private Animator anim;
    private Action onComplete;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    public void Show(Action OnComplete)
    {
        onComplete = OnComplete;
        anim.enabled = true;
    }
    public void OnShowComplete()
    {
        onComplete?.Invoke();
    }
}
