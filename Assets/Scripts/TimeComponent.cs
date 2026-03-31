using TMPro;
using UnityEngine;

public class TimeComponent : MonoBehaviour
{
    private float time = 0.0f;

    private TextMeshProUGUI text = null;

    private bool couting = true;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        if(couting)
            time += Time.deltaTime;
        
        text.text = SecondsToHMS(time);
    }

    private string SecondsToHMS(float time)
    {
        int t = (int)time;
        int h = t / 3600;
        t %= 3600;
        int m = t / 60;
        t %= 60;
        int s = t;

        string str = "";
        str += h > 0 ? h + "h" : "";
        if (m > 0)
        {
            if (m >= 10)
            {
                str += m;
            }
            else
            {
                str += "0" + m;
            }
            str += "m";
        }
        if (s > 0)
        {
            if (s >= 10)
            {
                str += s;
            }
            else
            {
                str += "0" + s;
            }
            str += "s";
        }
        else
        {
            str += "00s";
        }
        
        return str;
    }

    public void StartCounting()
    {
        couting = true;
    }

    public void StopCouting()
    {
        couting = false;
    }

    public void ResetTimeCounter()
    {
        time = 0.0f;
        StopCouting();
    }

    public string GetText()
    {
        return text.text;
    }
}
