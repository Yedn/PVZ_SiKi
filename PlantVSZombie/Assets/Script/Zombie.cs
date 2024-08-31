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
    public int Hp = 100;
    private int currentHp;
    public GameObject zombieHeadPrefab;
    private bool haveHead = true;

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
        currentHp = Hp;
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

    public void TakeDamage(int Damage)
    {
        if (currentHp <= 0 )
        {
            return;
        }
        this.currentHp -= Damage;
        if (currentHp <= 0)
        {
            currentHp = -1;
            Dead();
        }
        float hpPercent = (currentHp * 1.0f) / Hp;
        
        anim.SetFloat("HpPercent", hpPercent);
        if (hpPercent < 0.5f && haveHead == true)
        {
            GameObject go = GameObject.Instantiate(zombieHeadPrefab, transform.position, Quaternion.identity);
            Destroy(go, 2.0f);
            haveHead = false;
        }

    }
    private void Dead()
    {
        zombieState = ZombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject,2.0f);
    }
}
