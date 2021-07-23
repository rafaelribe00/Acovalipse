using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEfect;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if(hitInfo)
        {
            if(hitInfo.transform.CompareTag("NormEnemy"))
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if(enemy != null)
                {
                    Debug.Log("We hit a enemy");
                    enemy.TakeDamage(damage);
                }
            } else if(hitInfo.transform.CompareTag("Boss"))
            {
                BossFire boss = hitInfo.transform.GetComponent<BossFire>();
                if(boss != null)
                {
                    Debug.Log("We hit the boss");
                    boss.TakeDamage(damage);
                }
            }

            Instantiate(impactEfect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        } else 
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}
