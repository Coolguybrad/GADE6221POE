using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (message == null)
        {
            message = GameObject.Find("txtMessage").GetComponent<TMP_Text>();
            emailIn = GameObject.Find("txfEmail").GetComponent<TMP_InputField>();
            emailIn = GameObject.Find("txfPassword").GetComponent<TMP_InputField>();
            loginUI = GameObject.Find("LogInCanvas").GetComponent<Canvas>();
            mainUI = GameObject.Find("MainMenu Canvas").GetComponent<Canvas>();
            displayNameUI = GameObject.Find("DisplayNameMenu").GetComponent<Canvas>();
            displayName = GameObject.Find("displayNameInput").GetComponent<TMP_InputField>();
        }
    }

    

    // Start is called before the first frame update
    public TMP_Text message;
    //login
    public TMP_InputField emailIn;
    public TMP_InputField passIn;
    //canvases
    public Canvas loginUI;
    public Canvas mainUI;
    public Canvas displayNameUI;
    

    //Displayname ui
    public TMP_InputField displayName;


    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "Main Menu")
        //{
        //    if (message == null)
        //    {
        //        message = GameObject.Find("txtMessage").GetComponent<TMP_Text>();
        //        emailIn = GameObject.Find("txfEmail").GetComponent<TMP_InputField>();
        //        emailIn = GameObject.Find("txfPassword").GetComponent<TMP_InputField>();
        //        loginUI = GameObject.Find("LogInCanvas").GetComponent<Canvas>();
        //        mainUI = GameObject.Find("MainMenu Canvas").GetComponent<Canvas>();
        //        displayNameUI = GameObject.Find("DisplayNameMenu").GetComponent<Canvas>();
        //        displayName = GameObject.Find("displayNameInput").GetComponent<TMP_InputField>();
        //    }
        //}
    }

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
        DataManager.instance.loggedIn = true;
        StartCoroutine(switchUI());
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
        {
            Email = emailIn.text,
            Password = passIn.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams { GetPlayerProfile = true }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        message.text = "logged in";
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;

        }
        if (name == null)
        {
            loginUI.gameObject.SetActive(false);
            displayNameUI.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(switchUI());
            DataManager.instance.loggedIn = true;
        }



    }

    public void btnSubmit()
    {
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayName.text };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated");
        StartCoroutine(switchUI());
    }

    IEnumerator switchUI()
    {
        yield return new WaitForSeconds(1);
        loginUI.gameObject.SetActive(false);
        displayNameUI.gameObject.SetActive(false);
        mainUI.gameObject.SetActive(true);

    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
