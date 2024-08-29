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
        //·����ʱ�䣬��������(����ƽ����SetEase:�ȿ����
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);
        
    }
}
 