using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    static PlayFabManager instance;

    
        private void Awake()
        {
            if (instance == null) //if else makes sure theres only one instance of the game manager
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);

            }
        }
    

    // Start is called before the first frame update
    public TMP_Text message;
    public TMP_InputField emailIn;
    public TMP_InputField passIn;
    public void btnRegister() 
    {
        if (passIn.text.Length < 6)
        {
            message.text = "Password too short";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailIn.text,
            Password = passIn.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result) 
    {
        message.text = "Registered and Logged in";
    }


    private void OnError(PlayFabError e) 
    {
        message.text = e.ErrorMessage;
        Debug.Log(e.GenerateErrorReport());
    }
    

    public void btnLogin() 
    {
        if (passIn.text.Length < 6)
        {
            message.text = "Password too short";
            return;
        }
        var request = new LoginWithEmailAddressRequest
        {Email = emailIn.text,
        Password = passIn.text};
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult result) 
    {
        message.text = "logged in";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
