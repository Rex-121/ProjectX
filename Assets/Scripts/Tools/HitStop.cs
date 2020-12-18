using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{


    bool stopping;

    public float stopDuration;

    public float slowDuration;

    public void TimeStop()
    {

        if (!stopping)
        {
            stopping = true;
            Time.timeScale = 0;

            StartCoroutine(Stop());
        }
    }



    IEnumerator Stop() {
        yield return new WaitForSecondsRealtime(stopDuration);

        Time.timeScale = 0.01f;

        yield return new WaitForSecondsRealtime(slowDuration);

        Time.timeScale = 1;
        stopping = false;
    }


}
