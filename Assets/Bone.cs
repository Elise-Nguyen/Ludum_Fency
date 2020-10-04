using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [Range (1f, 100f)]
    public float boneSpeed;
    [Range (1f, 100f)]
    public float boneLifeSpan;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * boneSpeed, ForceMode2D.Impulse);
        StartCoroutine(Lifespan());
    }

    void OnTriggerEnter2D(Collider2D objectHit)
    {
        if(objectHit.tag =="Wall"){
            Destroy(gameObject);
        }
          
    }

    IEnumerator Lifespan()
    {
        yield return new WaitForSecondsRealtime(boneLifeSpan);
        Destroy(gameObject);
        yield return null;
    }


}
