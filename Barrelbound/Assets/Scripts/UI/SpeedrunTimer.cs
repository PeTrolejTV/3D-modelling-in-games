using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    [Header("Current Time Texts")]
    public List<TextMeshProUGUI> currentTimeTexts = new List<TextMeshProUGUI>();

    [Header("Best Time Texts")]
    public List<TextMeshProUGUI> bestTimeTexts = new List<TextMeshProUGUI>();

    [Header("Panels - always visible when enabled")]
    public List<GameObject> speedrunPanels = new List<GameObject>();

    [Header("Ingame Panel - hidden during pause/end screen")]
    public GameObject ingameTimerPanel;

    [Header("Settings")]
    public bool enabledByDefault = true;

    private const string BestTimeKey = "SpeedrunBestTime";

    private float _currentTime = 0f;
    private float _bestTime = 0f;
    private bool _running = false;
    private bool _timerEnabled;
    private bool _menuOpen = false;

    public float CurrentTime => _currentTime;
    public float BestTime => _bestTime;
    public bool IsRunning => _running;
    public bool IsEnabled => _timerEnabled;

    private void Awake()
    {
        _bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
        _timerEnabled = enabledByDefault;
        ApplyVisibility();
        UpdateAllTexts();
    }

    private void Update()
    {
        if (!_timerEnabled || !_running) return;
        _currentTime += Time.deltaTime;
        UpdateCurrentTimeTexts();
    }

    public void StartTimer()
    {
        if (!_timerEnabled) return;
        _currentTime = 0f;
        _running = true;
        UpdateAllTexts();
    }

    public void StopTimer()
    {
        if (!_running) return;
        _running = false;
        SaveBestTime();
        UpdateAllTexts();
    }

    public void ResetTimer()
    {
        _running = false;
        _currentTime = 0f;
        UpdateAllTexts();
    }

    public void SetEnabled(bool value)
    {
        _timerEnabled = value;
        if (!value) _running = false;
        ApplyVisibility();
        UpdateAllTexts();
    }

    public void ToggleEnabled()
    {
        SetEnabled(!_timerEnabled);
    }

    public void SetIngameTimerVisible(bool value)
    {
        _menuOpen = !value;
        RefreshIngamePanel();
    }

    private void ApplyVisibility()
    {
        foreach (var t in currentTimeTexts)
            if (t != null) t.gameObject.SetActive(_timerEnabled);

        foreach (var t in bestTimeTexts)
            if (t != null) t.gameObject.SetActive(_timerEnabled);

        foreach (var p in speedrunPanels)
            if (p != null) p.SetActive(_timerEnabled);

        RefreshIngamePanel();
    }

    private void RefreshIngamePanel()
    {
        if (ingameTimerPanel != null)
            ingameTimerPanel.SetActive(_timerEnabled && !_menuOpen);
    }

    private void SaveBestTime()
    {
        if (_bestTime <= 0f || _currentTime < _bestTime)
        {
            _bestTime = _currentTime;
            PlayerPrefs.SetFloat(BestTimeKey, _bestTime);
            PlayerPrefs.Save();
        }
    }

    private void UpdateAllTexts()
    {
        UpdateCurrentTimeTexts();
        UpdateBestTimeTexts();
    }

    private void UpdateCurrentTimeTexts()
    {
        string formatted = FormatTime(_currentTime);
        foreach (var t in currentTimeTexts)
            if (t != null) t.text = formatted;
    }

    private void UpdateBestTimeTexts()
    {
        string formatted = _bestTime > 0f ? FormatTime(_bestTime) : "--:--.--";
        foreach (var t in bestTimeTexts)
            if (t != null) t.text = formatted;
    }

    public void ResetBestTime()
    {
        _bestTime = 0f;
        PlayerPrefs.DeleteKey(BestTimeKey);
        PlayerPrefs.Save();
        UpdateBestTimeTexts();
    }

    public static string FormatTime(float totalSeconds)
    {
        int hours   = (int)(totalSeconds / 3600);
        int minutes = (int)((totalSeconds % 3600) / 60);
        int seconds = (int)(totalSeconds % 60);
        int centis  = (int)((totalSeconds - Mathf.Floor(totalSeconds)) * 100);

        if (hours > 0)
            return $"{hours}:{minutes:00}:{seconds:00}.{centis:00}";
        if (minutes > 0)
            return $"{minutes}:{seconds:00}.{centis:00}";

        return $"{seconds}.{centis:00}";
    }
}