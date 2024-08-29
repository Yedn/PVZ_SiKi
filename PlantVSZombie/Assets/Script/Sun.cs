using UnityEngine;
using DG.Tweening;
using UnityEditor.Timeline;

public class Sun : MonoBehaviour
{
    public float moveDuration =1.0f;
    public void JumpTo(Vector3 targetPos)
    {
        Vector3 centerPos = (transform.position + targetPos) / 2;
        float distance = Vector3.Distance(transform.position, targetPos);
        centerPos.y += (distance / 2);
        //路径，时间，曲线类型(曲线平滑，SetEase:先快后慢
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);
        
    }
}
 