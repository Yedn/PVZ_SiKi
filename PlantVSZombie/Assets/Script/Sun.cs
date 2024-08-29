using UnityEngine;
using DG.Tweening;
using UnityEditor.Timeline;

public class Sun : MonoBehaviour
{
    public float moveDuration =1.0f;
    public int point = 25;
    public void JumpTo(Vector3 targetPos)
    {
        targetPos.z = -1;
        Vector3 centerPos = (transform.position + targetPos) / 2;
        float distance = Vector3.Distance(transform.position, targetPos);
        centerPos.y += (distance / 2);
        //路径，时间，曲线类型(曲线平滑，SetEase:先快后慢
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);
    }
    void OnMouseDown()
    {
        //()=> 回调函数
        //链式调用
        transform.DOMove(SunManager.Instance.GetSunPointTextPosition(), moveDuration).SetEase(Ease.OutQuad).OnComplete(() => { Destroy(this.gameObject); SunManager.Instance.AddSun(point); });
    }
}
 