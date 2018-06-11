using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonExtWiggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public int WiggleBeforeRest = 3;
    public float waitAtRest = 1;
    Coroutine wiggle;
    [SerializeField]
    float speed = 10;
    private float right = 10;
    private float left = -10;
    private float deltaTransition = 0.15F;
    private float lastTransition;


    IEnumerator wiggling() {
        while (true)
        {
            for (int i = 0; i < WiggleBeforeRest; i++)
            {
                yield return rotateObject(right);
                yield return rotateObject(left);
                yield return rotateObject(left);
                yield return rotateObject(right);
                transform.rotation = Quaternion.identity;
            }
            yield return new WaitForSecondsRealtime(waitAtRest);

        }
    }

    IEnumerator rotateObject(float target) {
        float goal = 0;
        while (goal < Mathf.Abs(target)) {
            float newTarget = (target - transform.rotation.z) * speed * Time.unscaledDeltaTime;
            goal += Mathf.Abs(newTarget);
            transform.Rotate(Vector3.back, newTarget);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator stopWiggling()
    {
        transform.rotation = Quaternion.identity;
        yield return null;

    }


    public void ResetCollider()
    {
        Destroy(this.gameObject.GetComponent<Collider2D>());
        this.gameObject.AddComponent<BoxCollider2D>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
            if (wiggle != null)
        {
            transform.rotation = Quaternion.identity;

            StopCoroutine(wiggle);
                wiggle = null;
            }
        if (checkLastTrans())
        {
            wiggle = StartCoroutine(wiggling());
            setLastTrans();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
            setLastTrans();
            if (wiggle != null)
        {
            transform.rotation = Quaternion.identity;

            StopCoroutine(wiggle);
                wiggle = null;
            }
            if (checkLastTrans())
            {
                wiggle = StartCoroutine(stopWiggling());
                setLastTrans();
            }
        }

    private bool checkLastTrans() {
        return Time.unscaledTime - lastTransition > deltaTransition;
    }
    private void setLastTrans() {
        lastTransition = Time.unscaledTime;
    }
}
