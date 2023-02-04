using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// The UI for displaying result
/// </summary>
public class ResultUI : MonoBehaviour
{
    private ResultUI() {}
    private static ResultUI _singleton;

    private static Animator _animator;
    private static readonly int _successAnimParam = Animator.StringToHash("success");

    private void Awake() {
        Singleton_Init();
    }
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void ShowSuccessUI(float delaySecond = 0f)
    {
        if(Cant_Execute()) return;

        if (delaySecond > 0f)
            _singleton.StartCoroutine(
                DelayCoroutine(delaySecond, ActivateSuccessUI));
        else
            ActivateSuccessUI();
    }

    public static void ShowFailedUI(float delaySecond = 1f)
    {
        if(Cant_Execute()) return;

        if (delaySecond > 0f)
            _singleton.StartCoroutine(
                DelayCoroutine(delaySecond, ActivateFailedUI));
        else
            ActivateFailedUI();
    }

    private void Singleton_Init() {
        _singleton = null;
        _singleton = this;
    }

    private static bool Cant_Execute() {
        return _singleton == null;
    }

    private static IEnumerator DelayCoroutine(float delaySecond, Action onDelayEnded)
    {
        yield return new WaitForSeconds(delaySecond);
        onDelayEnded.Invoke();
    }

    private static void ActivateSuccessUI()
    {
        _animator.enabled = true;
        _animator.SetBool(_successAnimParam, true);
    }

    private static void ActivateFailedUI()
    {
        _animator.enabled = true;
        _animator.SetBool(_successAnimParam, false);
    }
}
