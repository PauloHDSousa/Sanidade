                              using UnityEngine;

public class InteractablesObjects : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    float gainHumor = 1f;
    [SerializeField]
    float gainSanity = 1f;
    [SerializeField]
    float delayToUseAgain = 3f;

    [Header("SFX")]
    [SerializeField]
    AudioClip actionSound;

    [Header("UI")]
    [SerializeField]
    GameObject messageCanvas;

    [SerializeField]
    TMPro.TMP_Text tmpMessage;


    [SerializeField]
    string[] messages;

    float delay;
    MoodManager moodManager;
    AudioSource audioSource;
    PlayerActions playerActions; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moodManager = FindObjectOfType<MoodManager>();
        playerActions = FindObjectOfType<PlayerActions>();
    }

    void Update()
    {
        if (delay > 0)
            delay -= Time.deltaTime;
    }

    public void GainHumorAndSanity()
    {
        if (delay > 0)
            return;
         

        moodManager.ImproveHumor(gainHumor);
        moodManager.ImproveSanity(gainSanity);


        audioSource.PlayOneShot(actionSound);

        messageCanvas.SetActive(true);
        tmpMessage.text = GetRandomText();
        playerActions.SetPlayerInteract(false);
        if (delayToUseAgain == 0)
        {
            this.gameObject.SetActive(false);
            Invoke("DeleteFood", 2f);
            return;
        }

        delay = delayToUseAgain;

        Invoke("ResetAlpha", delayToUseAgain);
        this.gameObject.LeanAlpha(0.5f, 1f);
    }

    void DeleteFood()
    {
        playerActions.SetPlayerInteract(true);
        messageCanvas.SetActive(false);
        Destroy(this.gameObject);
    }

    void ResetAlpha()
    {
        playerActions.SetPlayerInteract(true);
        messageCanvas.SetActive(false);
        this.gameObject.LeanAlpha(1f, 1.5f);
    }

    string GetRandomText()
    {
        int random = Random.Range(0, messages.Length);
        return messages[random];
    }
}
