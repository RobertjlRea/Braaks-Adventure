using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Resources;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] float speed = 1;
    [SerializeField] bool  isHoming = true;
    [SerializeField] GameObject hitEffect = null;
    [SerializeField] float MaxLifeTime = 6f;
    [SerializeField] GameObject[] destroyonHit = null;
    [SerializeField] float lifeAfterImpact = 0.2f;

    Health target = null;
    GameObject instigator = null;
    float damage = 0;

    private void Start()
    {
        transform.LookAt(GetAimLocation());
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if(isHoming)
    {
        if(!target.IsDead())
        {
            transform.LookAt(GetAimLocation());
        }
    }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetTarget(Health target, GameObject instigator, float damage)
    {
        this.target = target;
        this.damage = damage;
        this.instigator = instigator;
        
        Destroy(gameObject, MaxLifeTime);
    }
    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
             return target.transform.position;
        }
        
        return target.transform.position + Vector3.up * targetCapsule.height / 2;

    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.GetComponent<Health>() != target) return;
       if(target.IsDead()) return;
       target.TakeDamage(instigator, damage);
           if (hitEffect != null)
       {
           Instantiate(hitEffect, GetAimLocation(), transform.rotation);
       }

       foreach (GameObject toDestroy in destroyonHit)
       {
           Destroy(toDestroy);
       }
       Destroy(gameObject, lifeAfterImpact);
    }
}
