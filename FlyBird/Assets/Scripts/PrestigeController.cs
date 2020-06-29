using System.Collections;
using UnityEngine;
using System;


public class PrestigeController : MonoBehaviour 
{
    public void SendPrestigeOnServer()
    {
        StartCoroutine(StartSendPrestige());
    }

    private IEnumerator StartSendPrestige()
    {
        //var www = new WWW(string.Format("http://arturpinchukov.pythonanywhere.com/save?game_state_id={0}&name={1}&prestige={2}",
        //var www = new WWW(string.Format("http://192.168.137.212:8080/save_prestige_quiz_word?game_state_id={0}&name={1}&prestige={2}",
        //var www = new WWW(string.Format("http://arturpinchukov.pythonanywhere.com/save_prestige_quiz_word?game_state_id={0}&name={1}&prestige={2}",
        var www = new WWW(string.Format("http://127.0.0.1:8000/save?game_state_id={0}&name={1}&prestige={2}",
            //"test1", "test1", 10));
            "1", "Nikolay", PlayerPrefs.GetInt("BestScore")));

        yield return www;
    }

    public void LoadLeaderBoard(Action onError, Action<Hashtable> onLoadBoard)
    {
        StartCoroutine(StartLoadLeaderBoard(onError, onLoadBoard));
    }
	
	
    private IEnumerator StartLoadLeaderBoard(Action onError, Action<Hashtable> onLoadBoard)
    {
        var www = new WWW(string.Format("http://127.0.0.1:8000/get_leder?game_state_id={0}&user_name={1}",
            //var www = new WWW(string.Format("http://192.168.137.212:8080/prestige_quiz_word?game_state_id={0}&user_name={1}",
            "test", "test"));
            //GameState.Instance.GameId, GameState.Instance.UserName));

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            onError();
            Debug.LogError("Server error-" + www.error);
            yield break;
        }

        if (string.IsNullOrEmpty(www.text))
        {
            onError();
            Debug.LogError("Server return null data");
            yield break;
        }

        var leaderboard = JSON.JsonDecode(www.text);
        if (leaderboard == null)
        {
            onError();
            Debug.LogError("Server return error data");
            yield break;
        }

        onLoadBoard(leaderboard);
    }
	
}


