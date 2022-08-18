using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class MoodManager : MonoBehaviour
{

    [Header("Mood Bards")]
    [SerializeField]
    Image sanidadeBar;
    [SerializeField]
    Image humorBar;

    [Header("Configuration")]
    [SerializeField]
    float drainSanity = 5f;
    [SerializeField]
    float drainHumor = 5f;
    [SerializeField]
    float timeDrainSanity = 10f;
    [SerializeField]
    float timeDrainHumor = 5f;

    [Header("Managers")]
    [SerializeField]
    AudioSource audioSource;

    float maxSanidade = 100;
    float maxHumor = 100;

    float currentSanidade = 100f;
    float currentHumor = 100f;

    void Start()
    {
        InvokeRepeating("DrainSanity", timeDrainSanity, timeDrainSanity);
        InvokeRepeating("DrainHumor", timeDrainHumor, timeDrainHumor);
    }

    private void Update()
    {
        humorBar.fillAmount = currentHumor / maxHumor;
        sanidadeBar.fillAmount = currentSanidade / maxSanidade;

        AudioMood();
    }

    void DrainSanity()
    {
        currentSanidade -= drainSanity;
    }

    void DrainHumor()
    {
        currentHumor -= drainHumor;
    }

    public void ImproveHumor(float _humor)
    {
        currentHumor += _humor;
        if (currentHumor > maxHumor)
            currentHumor = maxHumor;
    }

    public void ImproveSanity(float _sanidade)
    {
        currentSanidade += _sanidade;
        if (currentSanidade > maxSanidade)
            currentSanidade = maxSanidade;
    }

    void AudioMood()
    {

        if (currentHumor >= 75 && currentSanidade >= 75)
            audioSource.pitch = 1f;
        else if ((currentHumor <= 75 || currentSanidade <= 75) && audioSource.pitch == 1)
            audioSource.pitch = 1.1f;
        else if ((currentHumor <= 50 || currentSanidade <= 50) && audioSource.pitch == 1.1)
            audioSource.pitch = 1.2f;
        else if ((currentHumor <= 25 || currentSanidade <= 25) && audioSource.pitch == 1.2)
            audioSource.pitch = 1.3f;
    }

    public float GetCurrentSanidade()
    {
        return currentSanidade;
    }
    public float GetCurrentHumor()
    {
        return currentHumor;
    }
}
