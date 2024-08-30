using UnityEngine;

enum PlantState
{
    Disable,
    Enable
}

public class Plant : MonoBehaviour
{
    [Header("Plant Basic Information")]
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.Sunflower;
    public int Hp = 100;

    private void Start()
    {
        TransitionToDisable();
    }

    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
        }
    }

    private void DisableUpdate()
    {
        
    }
    protected virtual void EnableUpdate()
    {

    }
    private void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public void TakeDamage(int Damage)
    {
        this.Hp -= Damage;
        if (this.Hp <= 0) 
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }


}
