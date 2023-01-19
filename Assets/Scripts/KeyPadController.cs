using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadController : MonoBehaviour
{
    public int Password;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button9;
    private Button button0;
    private Button buttonGo;
    private Button buttonDelete;
    
    public GameObject Door;
    public int MaxInputLength;
    private GameObject inputObject;
    private string input = "";

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = "Password...";
        button1 = gameObject.transform.GetChild(1).GetComponent<Button>();
        button2 = gameObject.transform.GetChild(2).GetComponent<Button>();
        button3 = gameObject.transform.GetChild(3).GetComponent<Button>();
        button4 = gameObject.transform.GetChild(4).GetComponent<Button>();
        button5 = gameObject.transform.GetChild(5).GetComponent<Button>();
        button6 = gameObject.transform.GetChild(6).GetComponent<Button>();
        button7 = gameObject.transform.GetChild(7).GetComponent<Button>();
        button8 = gameObject.transform.GetChild(8).GetComponent<Button>();
        button9 = gameObject.transform.GetChild(9).GetComponent<Button>();
        button0 = gameObject.transform.GetChild(10).GetComponent<Button>();
        buttonGo = gameObject.transform.GetChild(11).GetComponent<Button>();
        buttonDelete = gameObject.transform.GetChild(12).GetComponent<Button>();
        
        button1.onClick.AddListener(TaskOnClick1);
        button2.onClick.AddListener(TaskOnClick2);
        button3.onClick.AddListener(TaskOnClick3);
        button4.onClick.AddListener(TaskOnClick4);
        button5.onClick.AddListener(TaskOnClick5);
        button6.onClick.AddListener(TaskOnClick6);
        button7.onClick.AddListener(TaskOnClick7);
        button8.onClick.AddListener(TaskOnClick8);
        button9.onClick.AddListener(TaskOnClick9);
        button0.onClick.AddListener(TaskOnClick0);
        buttonGo.onClick.AddListener(TaskOnClickGo);
        buttonDelete.onClick.AddListener(TaskOnClickDelete);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    

    
    void TaskOnClick1()
    {
        Debug.Log("clicked on 1");
        if (input.Length < MaxInputLength)
        {
            input = input + "1";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick2()
    {
        Debug.Log("clicked on 2");
        if (input.Length < MaxInputLength)
        {
            input = input + "2";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick3()
    {
        Debug.Log("clicked on 3");
        if (input.Length < MaxInputLength)
        {
            input = input + "3";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick4()
    {
        Debug.Log("clicked on 4");
        if (input.Length < MaxInputLength)
        {
            input = input + "4";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick5()
    {
        Debug.Log("clicked on 5");
        if (input.Length < MaxInputLength)
        {
            input = input + "5";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick6()
    {
        Debug.Log("clicked on 6");
        if (input.Length < MaxInputLength)
        {
            input = input + "6";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick7()
    {
        Debug.Log("clicked on 7");
        if (input.Length < MaxInputLength)
        {
            input = input + "7";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick8()
    {
        Debug.Log("clicked on 8");
        if (input.Length < MaxInputLength)
        {
            input = input + "8";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick9()
    {
        Debug.Log("clicked on 9");
        if (input.Length < MaxInputLength)
        {
            input = input + "9";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    void TaskOnClick0()
    {
        Debug.Log("clicked on 0");
        if (input.Length < MaxInputLength)
        {
            input = input + "0";
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    
    void TaskOnClickGo()
    {
        if (input.Equals(Password.ToString()))
        {
            GameObject.Find("Camera").GetComponent<MouseLook>().enabled = true;
            Debug.Log("PASSWORD IS CORRECT");
            Door.GetComponent<PasswordDoorController>().OpenDoor();
            Cursor.visible = false;
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
    void TaskOnClickDelete()
    {
        if (input.Length > 0)
        {
            input = input.Remove(input.Length - 1);
            gameObject.transform.GetChild(14).GetComponent<TMPro.TextMeshProUGUI>().text = input;
        }
        
    }
    
}
