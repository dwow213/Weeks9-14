using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public float timeAnHourTakes = 5;

    public GameObject bird;
    public AudioSource sound;
    public int cuckooAmount;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine clockIsRunning;
    IEnumerator doOneHour;

    void Start()
    {
        clockIsRunning = StartCoroutine(MoveTheClock());
    }

    private IEnumerator MoveTheClock()
    {
        while (true)
        {
            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doOneHour);
        }
    }

    private IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
        Coroutine cuckoo = StartCoroutine(PlayCuckooSound());
        yield return cuckoo;
    }

    private IEnumerator PlayCuckooSound()
    {
        while (cuckooAmount < hour)
        {
            sound.Play();
            cuckooAmount += 1;

            bird.SetActive(true);
            yield return new WaitForSeconds(1);
            bird.SetActive(false);
        }

        cuckooAmount = 0;
    }
       
    public void StopTheClock()
    {
        if (clockIsRunning != null)
        {
            StopCoroutine(clockIsRunning);
        }
        

        StopCoroutine(doOneHour);
    }
}
