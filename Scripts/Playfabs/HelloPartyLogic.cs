/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.Party;
using PlayFab.ClientModels;

public class HelloPartyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Log into playfab
        var request = new LoginWithCustomIDRequest { CustomId = UnityEngine.Random.value.ToString(), CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLoginSuccess(LoginResult result)
    {

    }

    private void OnLoginFailure(PlayFabError error)
    {

    }
}
*/