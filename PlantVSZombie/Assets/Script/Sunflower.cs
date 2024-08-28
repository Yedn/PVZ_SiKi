using UnityEngine;

public class Sunflower : Plant
{
    public float productDuration = 5.0f;
    private float productTime = 0.0f;

    public Animator anim;

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
        Debug.Log("Born Sun");
    }
}
