using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyImpactEffectClones : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
