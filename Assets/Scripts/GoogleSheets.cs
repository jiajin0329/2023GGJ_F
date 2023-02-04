using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleSheets : MonoBehaviour
{
    [SerializeField] private Text[] leaderboard;
    [SerializeField] private ScoreObject score;
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
        string url = "https://script.google.com/macros/s/AKfycby40QVHPl1un3eqxL5ML58SQtFJlFfiDnnevIYdIJL2o6olvUihJt0Dq9JjeQEczRQ/exec";
        UnityWebRequest requests = UnityWebRequest.Post(url, form);
        yield return requests.SendWebRequest();

        if (requests.result == UnityWebRequest.Result.ProtocolError || requests.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(requests.error);
        }
        else
        {
            string[] scores = requests.downloadHandler.text.Split(',');
            for (int i = 0;i< 5; i++)
            {
                leaderboard[i].text = (i+1) + ": " + scores[i];
            }

        }
    }
}
