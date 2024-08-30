using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 3.0f;
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
