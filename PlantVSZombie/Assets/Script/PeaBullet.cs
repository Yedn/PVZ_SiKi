using Unity.VisualScripting;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    [Header("Attack")]
    private int atkValue = 25;
    private float speed = 3.0f;

    public void Start()
    {
        Destroy(gameObject, 7.0f);
    }
    public void SetAtkValue(int atkValue)
    {
        this.atkValue = atkValue;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            Destroy(this.gameObject);
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
        }
    }
}
