using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Header("References")]
    public LightController lightController;

    [Header("Flicker Settings")]
    [Min(0.1f)] public float checkInterval = 10f;
    [Range(0f, 1f)] public float flickerChance = 0.25f;
    [Min(0f)] public float intervalVariance = 1f;

    private float _timer;
    private float _nextCheck;

    private void Awake()
    {
        if (lightController == null)
            lightController = GetComponent<LightController>();

        if (lightController == null)
            Debug.LogWarning($"[LightFlicker] Missing LightController on '{gameObject.name}'.");

        ScheduleNextCheck();
    }

    private void Update()
    {
        if (lightController == null) return;

        _timer += Time.deltaTime;

        if (_timer >= _nextCheck)
        {
            _timer = 0f;
            TryFlicker();
            ScheduleNextCheck();
        }
    }

    private void TryFlicker()
    {
        if (Random.value <= flickerChance)
            lightController.Flicker();
    }

    private void ScheduleNextCheck()
    {
        _nextCheck = Mathf.Max(0.1f, checkInterval + Random.Range(-intervalVariance, intervalVariance));
    }
}