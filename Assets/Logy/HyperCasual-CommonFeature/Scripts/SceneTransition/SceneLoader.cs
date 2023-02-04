using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    private SceneLoader() {}
    static SceneLoader _singleton;
    
    [SerializeField] float wait;
    [SerializeField] int start_scene_index;
    [SerializeField] Transition transition;

    private void Awake() {
        _singleton = null;
        _singleton = this;
    }
    
    /// <summary>
    /// load current scene
    /// </summary>
    public static  void ReLoadtScene(float wait) {
        _singleton.StartCoroutine(_singleton.DelayReLoadtScene(wait));
    }
    IEnumerator DelayReLoadtScene(float wait) {
        //if transition not null, wait transition cost_time
        if(transition != null) {
            TransitionSetting();
            transition.Play(0f);
            yield return new WaitForSeconds(transition.CostTime());
        }

        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// load next scene
    /// </summary>
    public static void NextScene(float wait) {
        _singleton.StartCoroutine(_singleton.DelayNextScene(wait));
    }
    private IEnumerator DelayNextScene(float wait) {
        //if transition not null, wait transition cost_time
        if(transition != null) {
            TransitionSetting();
            transition.Play(0f);
            yield return new WaitForSeconds(transition.CostTime());
        }
        yield return new WaitForSeconds(wait);
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(start_scene_index);
    }

    /// <summary>
    /// set how many seconds to wait execute LoadScene method
    /// </summary>
    public void SetWait(float wait) {
        this.wait = wait;
    }

    /// <summary>
    /// load index scene
    /// </summary>
    public static void LoadScene(int index) {
        _singleton.StartCoroutine(_singleton.DelayLoadScene(index));
    }
    private IEnumerator DelayLoadScene(int index) {
        //if transition not null, wait transition cost_time
        if(transition != null) {
            TransitionSetting();
            transition.Play(0f);
            yield return new WaitForSeconds(transition.CostTime());
        }
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(index);
    }

    private void TransitionSetting() {
        DontDestroyOnLoad(transition.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        transition.finish_distory = true;
        transition.Finish(0f);
    }
}
