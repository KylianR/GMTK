using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkBehaviour : MonoBehaviour {

    public Vector3 target;
    public FloatRange targetDistance;
    public FloatRange waitTime;

    void Start() {
        StartCoroutine(GoToTarget());
    }

    void SetTarget() {
        target = Random.insideUnitCircle * 
            Random.Range(targetDistance.min, targetDistance.max);
    }

    IEnumerator GoToTarget() {
        SetTarget();
        while (Vector3.Distance(transform.position, target) > 0.5f) {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(Random.Range(waitTime.min, 
                                                     waitTime.max));
        yield return StartCoroutine(GoToTarget());
    }
}
