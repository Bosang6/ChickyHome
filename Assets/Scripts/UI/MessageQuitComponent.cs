using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessageQuitComponent : MonoBehaviour
{
    [SerializeField]
    private Button btnYes = null;
    [SerializeField]
    private Button btnNo = null;
    
    void Start()
    {
        btnYes.onClick.AddListener(OnClickBtnYes);
        btnNo.onClick.AddListener(OnClickBtnNo);
        Hide();
    }

    public void OnClickBtnNo()
    {
        Hide();
    }

    public void OnClickBtnYes()
    {
        SceneManager.LoadScene("BeginScene");
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
