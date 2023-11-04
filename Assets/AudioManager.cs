using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource _titleMusic;
    [SerializeField] private AudioSource _levelMusic;
    private bool _titleMusicPlaying = false;
    private bool _levelMusicPlaying = false;

    [Header("Sounds")]
    [SerializeField] private AudioSource _jumpSource;
    [SerializeField] private AudioSource[] _stepSource;


    public void StartTitleMusic()
    {
        if (!_titleMusicPlaying)
        {
            _titleMusic.Play();
            _levelMusic.Stop();
            _titleMusic.volume = 0.5f;
            _levelMusicPlaying = false;
            _titleMusicPlaying = true;
        }
    }

    public void StartGameMusic()
    {
        if (!_levelMusicPlaying)
        {
            _levelMusic.Play();
            _titleMusic.Stop();
            _levelMusic.volume = 0.5f;
            _titleMusicPlaying = false;
            _levelMusicPlaying = true;
        }
    }
}
