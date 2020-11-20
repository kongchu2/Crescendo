using UnityEngine;

public class Metronome : MonoBehaviour
{
    public AudioSource music;

    private AudioSource metroSource;

    public static float musicTime;

    private float musicBPM;//음악의BPM
    private readonly float stdBPM = 60.0f;//기준BPM
    private float oneBeatTime;//한박자의시간
    private float offset;//음악의 시작점.
    private float offsetSample;//을 Sample값으로 환산.
    private float frequency;//음악파일frequency

    private float nextSample = 0f;//다음박자를칠때(샘플값)
    private float beatPerSample;//1박의시간
    private void Awake()
    {
        metroSource = GetComponent<AudioSource>();
        frequency = music.clip.frequency;
    }
    private void Start()
    {
        musicBPM = float.Parse(MusicManager.musicInfo["BPM"]);
        offset = float.Parse(MusicManager.musicInfo["Offset"]);

        oneBeatTime = stdBPM / musicBPM;
        offsetSample = frequency * offset;
        beatPerSample = oneBeatTime * frequency;
        nextSample += offsetSample;
    }
    private void Update()
    {
        if(music.timeSamples >= nextSample)
        {
            metroSource.Play();
            nextSample += beatPerSample;
        }
        musicTime = music.time;
    }
}
