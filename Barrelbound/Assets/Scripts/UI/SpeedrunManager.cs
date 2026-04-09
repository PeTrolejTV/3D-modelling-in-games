using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedrunManager : MonoBehaviour
{
    [Header("Current Time Texts")]
    public List<TextMeshProUGUI> currentTimeTexts = new List<TextMeshProUGUI>();
    [Header("Best Time Texts")]
    public List<TextMeshProUGUI> bestTimeTexts = new List<TextMeshProUGUI>();
    [Header("Panels")]
    public List<GameObject> speedrunPanels = new List<GameObject>();
    public GameObject ingameTimerPanel;

    public bool enabledByDefault = false;
    public bool allowBackgroundRunning = true;

    private const string BestTimeKey = "SpeedrunBestTime";

    private static float _savedCurrentTime = 0f;
    private static bool _savedRunning = false;
    private static float _savedBestTime = 0f;
    private static bool _speedrunEnabled = false;

    private float _currentTime;
    private float _bestTime;
    private bool _running;
    private bool _uiVisible = false;

    public float CurrentTime => _currentTime;
    public float BestTime => _bestTime;
    public bool IsRunning => _running;
    public bool IsUIVisible => _uiVisible;

    public static bool SpeedrunEnabled
    {
        get => _speedrunEnabled;
        set
        {
            _speedrunEnabled = value;
            UpdateAllManagers();
        }
    }

    private static bool _anyMenuOpen = false;
    public static bool AnyMenuOpen
    {
        get => _anyMenuOpen;
        set
        {
            _anyMenuOpen = value;
            UpdateAllManagers();
        }
    }

    private static void UpdateAllManagers()
    {
        var managers = Object.FindObjectsByType<SpeedrunManager>(FindObjectsSortMode.None);
        foreach (var m in managers)
        {
            m._uiVisible = _speedrunEnabled || m.enabledByDefault;
            m.ApplyVisibility();
            m.UpdateAllTexts();
        }
    }

    private void Awake()
    {
        _bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
        if (_savedBestTime > 0f) _bestTime = _savedBestTime;

        _currentTime = _savedCurrentTime;
        _running = _savedRunning;
        _uiVisible = _speedrunEnabled || enabledByDefault;

        ApplyVisibility();
        UpdateAllTexts();
    }

    private void OnEnable()
    {
        ApplyVisibility();
        UpdateAllTexts();
    }

    private void Update()
    {
        if (!_running) return;
        _currentTime += Time.deltaTime;
        _savedCurrentTime = _currentTime;
        _savedRunning = _running;
        UpdateCurrentTimeTexts();
    }

    public void StartTimer(bool forceBackground = false)
    {
        if (!_uiVisible && !forceBackground && !allowBackgroundRunning) return;
        if (!_running)
            _currentTime = 0f;
        _running = true;
        _savedRunning = true;
        UpdateAllTexts();
    }

    public void StopTimer()
    {
        if (!_running) return;
        _running = false;
        _savedRunning = false;
        SaveBestTime();
        UpdateAllTexts();
    }

    public void ResetTimer()
    {
        _running = false;
        _currentTime = 0f;
        _savedCurrentTime = 0f;
        _savedRunning = false;
        UpdateCurrentTimeTexts();
    }

    public void ResetBestTime()
    {
        _bestTime = 0f;
        _savedBestTime = 0f;
        PlayerPrefs.SetFloat(BestTimeKey, 0f);
        PlayerPrefs.Save();
        UpdateBestTimeTexts();
    }

    public void SetEnabled(bool value)
    {
        SpeedrunEnabled = value;
    }

    public void SetIngameTimerVisible(bool value)
    {
        _uiVisible = value;
        RefreshIngamePanel();
    }

    private void RefreshIngamePanel()
    {
        bool shouldShow = _uiVisible && !_anyMenuOpen;
        if (ingameTimerPanel != null)
            ingameTimerPanel.SetActive(shouldShow);
    }

    private void ApplyVisibility()
    {
        foreach (var t in currentTimeTexts)
            if (t != null) t.gameObject.SetActive(_uiVisible);
        foreach (var t in bestTimeTexts)
            if (t != null) t.gameObject.SetActive(_uiVisible);
        foreach (var p in speedrunPanels)
            if (p != null) p.SetActive(_uiVisible);

        RefreshIngamePanel();
    }

    private void SaveBestTime()
    {
        if (_currentTime > 0f && (_bestTime <= 0f || _currentTime < _bestTime))
        {
            _bestTime = _currentTime;
            _savedBestTime = _bestTime;
            PlayerPrefs.SetFloat(BestTimeKey, _bestTime);
            PlayerPrefs.Save();
        }
        UpdateBestTimeTexts();
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

    public static void ClearTimerData()
    {
        _savedCurrentTime = 0f;
        _savedRunning = false;
    }

    public static string FormatTime(float totalSeconds)
    {
        int hours = (int)(totalSeconds / 3600);
        int minutes = (int)((totalSeconds % 3600) / 60);
        int seconds = (int)(totalSeconds % 60);
        int centis = (int)((totalSeconds - Mathf.Floor(totalSeconds)) * 100);

        if (hours > 0)
            return $"{hours}:{minutes:00}:{seconds:00}.{centis:00}";
        if (minutes > 0)
            return $"{minutes}:{seconds:00}.{centis:00}";
        return $"{seconds}.{centis:00}";
    }
}