using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Beats : MonoBehaviour {

    //publics
    //public float _loudnessThreshold; // old number for cehcking against loudness of song to identify beat
    public float _timeThreshhold;
    public GameObject menu;

    //privates
    AudioSource _audio;
    float _timeOfSwap;
    float _time;
    float bpm;
    float timeBetweenBeat;
    float beatCounter;

    // Use this for initialization
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        _timeOfSwap = 0;
        _time = Time.time;
        timeBetweenBeat = Beat();
        _audio.Play();
        beatCounter = 0;
    }

    public bool DamageTime()
    {
        //float loudness = ParseAudio();
        _time += Time.deltaTime;

        // if dmg time then should 'freeze' the value for a period of time done by not rechecking
        // against the threshold and just returning true for the period
        if (_time + _timeOfSwap > _timeOfSwap + _timeThreshhold)
        {
            if (Time.time % timeBetweenBeat <= 0.1f )
            {
                _timeOfSwap = _time;
                _time = 0;
                beatCounter++;
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    // get whether the song is playing
    private void FixedUpdate()
    {
        if(!_audio.isPlaying)
        {
            menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public bool SongPlaying()
    {
        if(_audio.isPlaying)
        {
            return true;
        }
        return false;
    }

    public void PlaySong()
    {
        beatCounter = 0;
        _audio.Play();
    }

    /*
    // calculates a loudness value for the current moment
    float ParseAudio()
    {
        _audio.clip.GetData(_sample, _audio.timeSamples);
        float clipLoudness = 0f;
        foreach (var sample in _sample)
        {
            clipLoudness += Mathf.Abs(sample);
        }
        clipLoudness /= _sample.Length;
        return clipLoudness;
    } */

    float Beat()
    {
        bpm = 130f; // proper = 116, barbie = 130
        float timeBetweenBeat = 60.0f / bpm;
        return timeBetweenBeat;
    }
}
