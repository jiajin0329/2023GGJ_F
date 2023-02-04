using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Transition : MonoBehaviour {
    public bool finish_distory;

    [SerializeField] protected UnityEvent PlayEvent;
    [SerializeField] protected UnityEvent FinishEvent;
    [SerializeField] protected UnityEvent EndEvent;

    void Awake() {
        EndEvent.AddListener(FinishDistory);
    }

    public void Play(float wait) {
        StartCoroutine(DelayPlay(wait));
    }
    protected virtual IEnumerator DelayPlay(float wait) {
        yield return new WaitForSeconds(wait);
        if(PlayEvent != null) PlayEvent.Invoke();
    }
    
    public void Stop(float wait) {
        StartCoroutine(DelayStop(wait));
    }
    protected virtual IEnumerator DelayStop(float wait) {
        yield return new WaitForSeconds(wait);
    }

    public void Finish(float wait) {
        StartCoroutine(DelayFinish(wait));
    }
    protected virtual IEnumerator DelayFinish(float wait) {
        yield return new WaitForSeconds(wait);
        if(FinishEvent != null) FinishEvent.Invoke();
    }

    public void End(float wait) {
        StartCoroutine(DelayEnd(wait));
    }
    protected virtual IEnumerator DelayEnd(float wait) {
        yield return new WaitForSeconds(wait);
        if(EndEvent != null) EndEvent.Invoke();
    }

    /// <summary>
    /// return cost_time
    /// </summary>
    public virtual float CostTime() {return 0f;}

    protected virtual void TransitionIn () {}
    protected virtual void TransitionOut() {}

    private void FinishDistory() {
        GameObject.Destroy(gameObject);
    }
}