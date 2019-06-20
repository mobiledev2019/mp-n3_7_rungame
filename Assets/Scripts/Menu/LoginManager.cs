using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using Firebase.Database;
using Object = System.Object;
using System.Linq;

public class LoginManager : MonoBehaviour
{

    public static LoginManager instance;

    public class User
    {
        public string id;
        public string account;
        public string pass;
        public string best;
        public string rank;

        public User()
        {

        }

        public User(string id,string account, string best,string pass,string rank)
        {
            this.id = id;
            this.account = account;
            this.best = best;
            this.pass = pass;
            this.rank = rank;
        }
    }


    //
    public FirebaseAuth auth { get; private set; }
    public FirebaseUser user { get; private set; }
    public string displayName { get; private set; }
    public string emailAddress { get; private set; }
    public string photoUrl { get; private set; }
    public string googleIdToken { get; private set; }
    public string googleAccessToken { get; private set; }

    [Header("UI")]
    public Button btnLogin;
    public Button btnOK, btnRegister,btnShowRegister, btnShowAcc, btnExitAcc;
    public GameObject panelLogin, loginObj, errorObj, panelRegister,panelMenu, panelAccount;
    public Text textUser,textPass;

    public Text textUserR, textPassR;

    public Text textAcc, textBest, textRank;
    public bool loadDone = false;
    public bool checkDone = true;


    [HideInInspector]
    public List<User> listUser = new List<User>();
    [HideInInspector]
    public  List<User> listLeaderBoard = new List<User>();

    public List<GameObject> listPlayer = new List<GameObject>();

    DatabaseReference reference;


    private const string DB = "https://impossibleroad.firebaseio.com/";


    

    private void Awake()
    {
        CheckUpdate();
        instance = this;
        StartCoroutine(Example());
    }

    private void Start()
    {
        

        //Invoke("SortListUser", 5);
    }

    IEnumerator Example()
    {
        yield return new WaitUntil(() => checkDone == true);
        print("checkDone");
        InitializeFirebase();
        GetDataFromDB();
    }

    public void ShowAccount()
    {
        btnShowAcc.gameObject.SetActive(false);
        panelAccount.SetActive(true);
        panelMenu.SetActive(false);

        GetDataFromDB();
        SortListUser();

        User local = FindAccount(GameManager.instance.GetUser());
        int index = 0;

        for (int i = 0; i < listLeaderBoard.Count; i++)
        {
            if (local.account.Equals(listLeaderBoard[i].account))
            {
                index = i;
                break;
            }
        }


        int rank = listLeaderBoard.Count - index;
        GameManager.instance.SetRank(rank);

        textAcc.text = GameManager.instance.GetUser();
        textBest.text = GameManager.instance.GetBest().ToString();
        textRank.text = GameManager.instance.GetRank().ToString();

        btnExitAcc.onClick.AddListener(() =>
        {
            panelAccount.SetActive(false);
            panelMenu.SetActive(true);
            btnShowAcc.gameObject.SetActive(true);
        });

    }

    void CheckUpdate()
    {
        checkDone = false;
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
            checkDone = true;
        });
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void Login()
    {
        panelMenu.SetActive(false);
        panelLogin.SetActive(true);
        loginObj.SetActive(true);
        errorObj.SetActive(false);

        btnLogin.onClick.AddListener(() =>
        {
            CheckLogin();
        });

        btnShowRegister.onClick.AddListener(() =>
        {
            loginObj.SetActive(false);
            panelRegister.SetActive(true);
            btnRegister.onClick.AddListener(Register);
        });

    }

    public void Register()
    {
        CheckRegister();
    }


    

    public void AddDataToFB(string id, string account, string best, string pass,string rank) 
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DB);
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        User user = new User(id,account, best,pass,rank);
        string json = JsonUtility.ToJson(user);

        print(json);

        reference.Child("users").Child(id).SetRawJsonValueAsync(json);
    }

    public void GetDataFromDB()
    {
        listUser.Clear();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DB);
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;
                    print("zo");
                    User temp = new User(dictUser["id"].ToString(), dictUser["account"].ToString(), dictUser["best"].ToString(),
                        dictUser["pass"].ToString(), dictUser["rank"].ToString());
                    listUser.Add(temp);
                }
                loadDone = true;
            }
        });
        
    }

    public void LoadDataToLeaderBoard()
    {

        SortListUser();

        int index = listLeaderBoard.Count;

        for(int i = 0; i < listPlayer.Count; i++)
        {
            listPlayer[i].transform.GetChild(1).GetComponent<Text>().text = listLeaderBoard[index - i - 1].account;
            listPlayer[i].transform.GetChild(2).GetComponent<Text>().text = listLeaderBoard[index - i - 1].best;
        }
    }


    void CheckRegister()
    {
        string user = textUserR.text;
        string pass = "";
        if (textPassR.text.Length != 0)
        {
            pass = textPassR.GetComponentInParent<InputField>().text;
        }

        print("user : " + user);
        print("pass : " + pass);

        panelRegister.SetActive(false);
        errorObj.SetActive(true);

        if (CheckUserRegister(user,pass) == "done")
        {
            errorObj.transform.GetChild(1).GetComponent<Text>().text = "Register and login done!!! Hope you enjoy the game.";
            btnOK.onClick.AddListener(() =>
            {
                panelLogin.SetActive(false);
                panelMenu.SetActive(true);

                int id = listUser.Count + 1;

                AddDataToFB(id.ToString(), user, "0",pass,id.ToString());

                GameManager.instance.SetUser(user);
                GameManager.instance.SetID(id);
                GameManager.instance.SetPass(pass);
                GameManager.instance.SetRank(listUser.Count+1);
            });
        }
        else if (CheckUserRegister(user,pass) == "User and Pass can not null.")
        {
            errorObj.transform.GetChild(1).GetComponent<Text>().text = "User and Pass can not null.";
            btnOK.onClick.AddListener(() =>
            {
                errorObj.SetActive(false);
                panelRegister.SetActive(true);
                ResetFillTextRegister();
            });
        }
        else
        {
            errorObj.transform.GetChild(1).GetComponent<Text>().text = "User has been used.";
            btnOK.onClick.AddListener(() =>
            {
                errorObj.SetActive(false);
                panelRegister.SetActive(true);
                ResetFillTextRegister();
            });
        }
    }

    void CheckLogin()
    {

        string user = textUser.text;
        string pass = "";
        if (textPass.text.Length != 0)
        {
            pass = textPass.GetComponentInParent<InputField>().text;
        }

        loginObj.SetActive(false);
        errorObj.SetActive(true);

        if (CheckUserLogin(user,pass) == "Login succes!!")
        {
            User local = FindAccount(user);

            //textAcc.text = local.account;
            //textBest.text = local.best;
            //textRank.text = GameManager.instance.GetRank().ToString();

            GameManager.instance.SetUser(local.account);
            GameManager.instance.SetID(int.Parse(local.id));
            GameManager.instance.SetPass(local.pass);
            GameManager.instance.SetBest(int.Parse(local.best));
            errorObj.transform.GetChild(1).GetComponent<Text>().text = "Login done!!! Let's play the game.";
            btnOK.onClick.AddListener(() =>
            {
                panelMenu.SetActive(true);
                panelLogin.SetActive(false);
            });
            return;
        }
        else if (CheckUserLogin(user,pass) == "User and Password can not null.")
        {
            errorObj.transform.GetChild(1).GetComponent<Text>().text = "User and Password can not null.";
            btnOK.onClick.AddListener(() =>
            {
                errorObj.SetActive(false);
                loginObj.SetActive(true);
                ResetFillTextLogin();
            });
            return;

        }
        else
        {
            errorObj.transform.GetChild(1).GetComponent<Text>().text = "User or Password is incorrect." + pass;
            btnOK.onClick.AddListener(() =>
            {
                errorObj.SetActive(false);
                loginObj.SetActive(true);
                ResetFillTextLogin();
            });
            return;
        }
    }

    string CheckUserLogin(string user,string pass)
    {

        print("user : " + user);
        print("pass : " + pass);

        

        if (user.Length == 0 || pass.Length == 0)
        {
            return "User and Password can not null.";
        }
        else {
            for (int i = 0; i < listUser.Count; i++)
            {
                if (user.Equals(listUser[i].account)) {
                    if (pass.Equals(listUser[i].pass))
                    {
                        return "Login succes!!";
                    }
                    else return "Password incorrect!!";
                }
            }
        }
        return "User incorrect";
    }

    string CheckUserRegister(string user,string pass)
    {
        if (user.Length == 0 || pass.Length == 0) return "User and Pass can not null.";
        for (int i = 0; i < listUser.Count; i++)
        {
            if (user.Equals(listUser[i].account)) return "User has been used.";
        }
        return "done";
    }


    void ResetFillTextLogin()
    {
        textPass.text = "";
        textUser.text = "";
    }

    void ResetFillTextRegister()
    {
        textPassR.text = "";
        textUserR.text = "";
    }

    void SortListUser()
    {
        listLeaderBoard.Clear();
        listLeaderBoard = listUser.OrderBy(user => int.Parse(user.best)).ToList();

        User local = new User(GameManager.instance.GetID().ToString(), GameManager.instance.GetUser(), 
            GameManager.instance.GetBest().ToString(), GameManager.instance.GetPass(),GameManager.instance.GetRank().ToString());

        int rank = listLeaderBoard.IndexOf(local);

        if (rank < GameManager.instance.GetRank())
        {
            Notify.instance.SendNotify();
            //GameManager.instance.SetRank(rank);
        }
    }

    public User FindAccount(string user)
    {
        User player = new User();
        for(int i = 0; i< listUser.Count; i++)
        {
            if (user.Equals(listUser[i].account))
            {
                player = new User(listUser[i].id, listUser[i].account, listUser[i].best, listUser[i].pass,listUser[i].rank);
                break;
            }
        }

        return player;
    }

}
