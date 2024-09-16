using UnityEngine;

public class Peashooter : Plant
{
    public float shootDuration = 2.0f;
    private float shootTime = 0.0f;
    public Transform shootPointTransform;
    public int atkValue = 25;

    public PeaBullet peaBulletPrefab;
    public float bulletSpeed=3.0f;
    protected override void EnableUpdate()
    {
        shootTime += Time.deltaTime;
        if (shootTime > shootDuration)
        {
            shoot();
            shootTime = 0.0f;
        }
    }

    void shoot()
    {
        AudioManager.instance.PlayClip(Config.shoot);
        PeaBullet pb = GameObject.Instantiate(peaBulletPrefab,shootPointTransform.position,Quaternion.identity);
        pb.SetSpeed(bulletSpeed);
        pb.SetAtkValue(atkValue);
    }
}
