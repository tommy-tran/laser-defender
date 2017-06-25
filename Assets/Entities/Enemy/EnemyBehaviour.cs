using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 200f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            Debug.Log(missile.getDamage());
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
