using UnityEngine;

enum ZombieState
{
    Move,Eat,Die
}


public class Zombie : MonoBehaviour
{
    private Rigidbody2D rgd;
    public float moveSpeed = 1.0f;
    ZombieState zombieState = ZombieState.Move;
    private Animator anim;

    [Header("EatPlant")]
    public int atkValue=25;
    public float atkDuration = 2.0f;
    public float atkTimer = 0;
    private Plant currentEatPlant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (zombieState)
        {
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Eat:
                EatUpdate();
                break;
            case ZombieState.Die:
                break;
        }


        
    }
    private void MoveUpdate()
    {
        rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void EatUpdate()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer>atkDuration && currentEatPlant != null)
        {
            currentEatPlant.TakeDamage(atkValue);
            atkTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsEating", true);
            TransitionToEat();
            currentEatPlant = collision.GetComponent<Plant>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsEating", false);
            zombieState = ZombieState.Move;
            currentEatPlant = null;
        } 
    }

    void TransitionToEat()
    {
        zombieState = ZombieState.Eat;
        atkTimer = 0.0f;
    }
}
