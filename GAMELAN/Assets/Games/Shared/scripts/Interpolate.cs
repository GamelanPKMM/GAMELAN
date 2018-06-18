using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interpolate : MonoBehaviour {
    public float speed = 1;
    private Coroutine appearing;
    public bool Enable()
    {
        return Enable(null);
    }
    public bool Disable()
    {
        return Disable(null);
    }
    public bool Enable(UnityAction action) {
        if (appearing == null)
        {
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
            appearing = StartCoroutine(interpolateScale(Vector3.one, action));
            return true;
        }
        return false;
    }
    public bool Disable(UnityAction action)
    {
        if (appearing == null)
        {
            transform.localScale = Vector3.one;
            appearing = StartCoroutine(interpolateScale(Vector3.zero, () =>
            {
                if(action!=null)
                action.Invoke();
                gameObject.SetActive(false);
            }));
            return true;
        }
        return false;
    }

    private IEnumerator interpolateScale(Vector3 target) {
        float interpol = 0;
        do
        {
            interpol += speed * Time.unscaledDeltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, target, interpol);
            yield return new WaitForEndOfFrame();
        } while (interpol < 0.2);
        transform.localScale = target;
        appearing = null;

    }
    private IEnumerator interpolatePos(Vector3 target)
    {
        float interpol = 0;
        do
        {
            interpol += speed * Time.unscaledDeltaTime;
            transform.position = Vector3.Lerp(transform.position, target, interpol);
            yield return new WaitForEndOfFrame();
        } while (interpol < 0.2);
        transform.position = target;
        appearing = null;
    }

    private IEnumerator interpolateScale(Vector3 target, UnityAction action)
    {
        yield return interpolateScale(target);
        if (action != null)
            action.Invoke();

    }

    private IEnumerator interpolatePos(Vector3 target, UnityAction action) {
        yield return interpolatePos(target);
        if (action != null)
            action.Invoke();

    }
    public void toggle() {
        if (gameObject.activeSelf)
        {
            Disable();
        }
        else {
            Enable();
        }
    }
}
