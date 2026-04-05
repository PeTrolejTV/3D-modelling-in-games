using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light targetLight;
    public Renderer emissionRenderer;
    public Color emissionColor = Color.white;
    public float maxEmissionIntensity = 500f;
    [Min(0f)] public float maxIntensity = 1f;
    public float transitionDuration = 0.3f;
    public float flickerDuration = 2f;
    [Range(2, 20)] public int flickerPulses = 16;
    public bool startOn = false;

    private bool _isOn;
    private Coroutine _activeCoroutine;
    private MaterialPropertyBlock _propBlock;

    public bool IsOn => _isOn;

    private void Awake()
    {
        if (targetLight == null)
            targetLight = GetComponent<Light>();

        if (emissionRenderer != null)
            _propBlock = new MaterialPropertyBlock();

        _isOn = startOn;

        if (targetLight != null)
            targetLight.intensity = _isOn ? maxIntensity : 0f;

        SetEmission(_isOn ? 1f : 0f);
    }

    public void TurnOn()
    {
        if (_isOn) return;
        _isOn = true;
        RunCoroutine(TransitionRoutine(maxIntensity, 1f));
    }

    public void TurnOff()
    {
        if (!_isOn) return;
        _isOn = false;
        RunCoroutine(TransitionRoutine(0f, 0f));
    }

    public void Toggle()
    {
        if (_isOn) TurnOff();
        else TurnOn();
    }

    public void Flicker()
    {
        RunCoroutine(FlickerRoutine());
    }

    public void TurnOnWithFlicker()
    {
        if (_isOn) return;
        _isOn = true;
        RunCoroutine(FlickerRoutine());
    }

    public void TurnOffWithFlicker()
    {
        if (!_isOn) return;
        _isOn = false;
        RunCoroutine(FlickerRoutine());
    }

    public void ToggleWithFlicker()
    {
        if (_isOn) TurnOffWithFlicker();
        else TurnOnWithFlicker();
    }

    private void RunCoroutine(IEnumerator routine)
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(routine);
    }

    private IEnumerator TransitionRoutine(float targetLightIntensity, float targetEmission)
    {
        float startLight = targetLight != null ? targetLight.intensity : 0f;
        float startEmission = 1f - targetEmission;
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / transitionDuration);

            if (targetLight != null)
                targetLight.intensity = Mathf.Lerp(startLight, targetLightIntensity, t);

            SetEmission(Mathf.Lerp(startEmission, targetEmission, t));
            yield return null;
        }

        if (targetLight != null)
            targetLight.intensity = targetLightIntensity;

        SetEmission(targetEmission);
        _activeCoroutine = null;
    }

    private IEnumerator FlickerRoutine()
    {
        float pulseTime = flickerDuration / flickerPulses;

        for (int i = 0; i < flickerPulses; i++)
        {
            float lightValue = Random.value > 0.4f
                ? Random.Range(0.6f, 1f)
                : Random.Range(0f, 0.2f);

            if (targetLight != null)
                targetLight.intensity = maxIntensity * lightValue;

            SetEmission(lightValue);
            yield return new WaitForSeconds(pulseTime * Random.Range(0.5f, 1.5f));
        }

        if (targetLight != null)
            targetLight.intensity = _isOn ? maxIntensity : 0f;

        SetEmission(_isOn ? 1f : 0f);
        _activeCoroutine = null;
    }

    private void SetEmission(float normalized)
    {
        if (emissionRenderer == null || _propBlock == null) return;
        emissionRenderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_EmissiveColor", emissionColor * (normalized * maxEmissionIntensity));
        emissionRenderer.SetPropertyBlock(_propBlock);
    }
}