using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider enemyBoxCollider;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int enemyScore = 12;
    // Start is called before the first frame update
    void Start()
    {
        addBoxCollider();
    }

    void addBoxCollider()
    {
        enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print(gameObject.name +" was hit by a bullet!");
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);

    }

    
}
