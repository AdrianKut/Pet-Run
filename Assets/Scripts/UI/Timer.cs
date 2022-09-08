using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _textTimer;
    public float Time { get; private set; }

    void Update()
    {
        if (GameManager.Instance.GameState == GameState.Playing)
            Tick();
    }

    private void Tick()
    {
        Time += UnityEngine.Time.deltaTime;

        float minutes = Mathf.FloorToInt(Time / 60);
        float seconds = Mathf.FloorToInt(Time % 60);
        float milliSeconds = (Time % 1) * 1000;

        _textTimer.text = string.Format("{0:00}:{1:00},{2:000}", minutes, seconds, milliSeconds);
    }

    public string GetTime()
    {
        return _textTimer.text;
    }
}
