using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Drag&Drop")] 
    [SerializeField] private AudioSource _bgm;
    [SerializeField] private AudioSource _sfx;

    [Header("AudioClip")]
    [SerializeField] private AudioClip[] _audioClips;
    
    private Dictionary<string, AudioClip> _clipDic;

    private bool _isPlayed;

    private float _curVolume;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    private void Start()
    {
        _curVolume = SettingManager.Instance.Sound.Value;
        SettingManager.Instance.Sound.OnChanged += SoundUpdate;
    }

    private void SoundUpdate(float value)
    {
        Debug.Log("진입");
        _curVolume = value;
        _bgm.volume = _curVolume;
    }
    
    private void OnDestroy()
    {
        SettingManager.Instance.Sound.OnChanged -= SoundUpdate;
    }
    
    public void PlayBGM(string clipName, bool loop)
    {
        if(_clipDic.TryGetValue(clipName, out AudioClip audioClip) && !_isPlayed)
        {
            _bgm.spatialBlend = 0;
            _bgm.clip = audioClip;
            _bgm.loop = loop;
            _bgm.Play();
            StartCoroutine(BGMFadeIn(_bgm, 3f));

            _isPlayed = true;
        }
    }

    public void StopBGM()
    {
        _isPlayed = false;
        StartCoroutine(BGMFadeOut(_bgm, 1f));
    }

    public void PlaySFX(string clipName)
    {
        if(_clipDic.TryGetValue(clipName, out AudioClip audioClip))
        {
            _sfx.PlayOneShot(audioClip);
        }
    }

    private IEnumerator BGMFadeIn(AudioSource source, float fadeTime)
    {
        float timer = 0f;
        while (fadeTime > timer)
        {
            source.volume = Mathf.Lerp(0f, _curVolume, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }

        source.volume = _curVolume;
    }

    private IEnumerator BGMFadeOut(AudioSource source, float fadeTime)
    {
        float timer = 0f;
        while (fadeTime > timer)
        {
            source.volume = Mathf.Lerp(_curVolume, 0f, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }
        source.Stop();
        source.volume = _curVolume;
    }
    
    private void Init()
    {
        _clipDic = new Dictionary<string, AudioClip>();
        {
            foreach (var clip in _audioClips)
            {
                _clipDic.Add(clip.name,clip);
            }
        }
        _isPlayed = false;
    }
}
