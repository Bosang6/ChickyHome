using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageGameOverComponent : MonoBehaviour
{
    [SerializeField]
    private Button btnYes = null;
    [SerializeField]
    private Button btnNo = null;

    [SerializeField]
    private TextMeshProUGUI result = null;
    
    private void Start()
    {
        btnYes.onClick.AddListener(OnClickBtnYes);
        btnNo.onClick.AddListener(OnClickBtnNo);
        Hide();
    }

    public void OnClickBtnNo()
    {
        SceneManager.LoadScene("BeginScene");
    }

    public void OnClickBtnYes()
    {
        GameManager.Instance.ResetGame();
        Hide();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void SetResultInMessage(string time)
    {
        result.text = "result: " + time;
    }
}
