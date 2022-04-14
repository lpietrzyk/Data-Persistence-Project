using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    public GameObject p_InputText;
    [SerializeField] TMP_Text Score;
    // Start is called before the first frame update
    void Start()
    {
        if (MenuManager.Instance.PlayerScore != 0)
        {
            Score.text = "BEST SCORE : " + MenuManager.Instance.BestPlayer.ToString() + " : " + MenuManager.Instance.PlayerScore.ToString();
        }
        else
        {
            Score.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void StartNew()
    {
        SubmitName(nameText.text);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

    private void SubmitName( string p_name)
    {
       MenuManager.Instance.PlayerName = p_name;
      
    }

}
