using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleSheets : MonoBehaviour
{
    [SerializeField] private Text[] leaderboard;
    [SerializeField] private ScoreObject score;
    [SerializeField] private InputField inputField;

    private bool loading;
        
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }
    }
    public void Save()
    {
        StartCoroutine(DoFunction());
    }

    IEnumerator DoFunction()
    {
        WWWForm form = new WWWForm();
        form.AddField("SCORE", score.score);
        form.AddField("NAME", inputField.text);
        string url = "https://script.google.com/macros/s/AKfycbwcYNL6lQl4E2z0ZgF11ShMDRmbUIa-sqmuRdI9wmqweDqo2IWqYx3_KHfhjWH_jDo/exec";
        UnityWebRequest requests = UnityWebRequest.Post(url, form);
        yield return requests.SendWebRequest();

        if (requests.result == UnityWebRequest.Result.ProtocolError || requests.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(requests.error);
        }
        else
        {
            string[] scores = requests.downloadHandler.text.Split(',');
            for (int i = 0; i < 5; i++)
            {
                leaderboard[i].text = (i + 1) + ": " + scores[i * 2] + "  " + scores[i * 2 + 1];
            }

        }
    }
}
