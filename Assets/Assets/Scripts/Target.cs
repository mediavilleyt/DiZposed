using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Animation flip;
    public GameObject target;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        isHit = true;
        flip.GetComponent<Animation>();
    }

    private void Update()
    {
        if(CD.Instance.whatHit == target && isHit)
        {
            isHit = false;
            CD.Instance.whatHit = null;
            StartCoroutine(FlipTarget());
        }
    }

    public IEnumerator FlipTarget()
    {
        flip.Play("TargetFlip");
        yield return new WaitForSeconds((float)(1 * Time.deltaTime));
        flip.Play("RTargetFlip");
        isHit= true;
        yield return null;
    }
}
