using Unity.VisualScripting;
using UnityEngine;

public class Sunflower : Plant
{
    [Header("Produce Sun Timer")]
    public float productDuration = 5.0f;
    private float productTime = 0.0f;

    [Header("Produce Sun")]
    public Animator anim;
    public GameObject sunPrefab;

    [Header("Sun Jump Offset Distance")]
    public float JumpMinDistance = 0.3f;
    public float JumpMaxDistance = 1.5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected override void EnableUpdate()
    {
        productTime += Time.deltaTime;
        if (productTime > productDuration)
        {
            anim.SetTrigger("IsGlowing");
            productTime = 0.0f;
        }
        base.EnableUpdate();
    }

    public void ProduceSun()
    {
        GameObject go = GameObject.Instantiate(sunPrefab, transform.position, Quaternion.identity);
        float distance = Random.Range(JumpMinDistance, JumpMaxDistance);
        distance = Random.Range(0, 2) < 1 ? -distance:distance;
        Vector3 position = transform.position;
        position.x += distance;
        go.GetComponent<Sun>().JumpTo(position);

        Debug.Log("Born Sun");
    }
}
