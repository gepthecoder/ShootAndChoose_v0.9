using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;
using UnityEngine.UI;


public class FacebookManager : MonoBehaviour
{

    public Text userIDText;

    private void Awake()
    {
        //if (!FB.IsInitialized) { FB.Init(); }
        //else { FB.ActivateApp(); }
    }

    public void LogIn()
    {
        //sign my user
        //FB.LogInWithReadPermissions(callback:OnLogIn);
    }

    private void OnLogIn(/*ILoginResult result*/)
    {
        //did user successfully log in?
        //if (FB.IsLoggedIn)
        //{
        //    AccessToken token = AccessToken.CurrentAccessToken;
        //    userIDText.text = token.UserId;
        //}
    }
}
