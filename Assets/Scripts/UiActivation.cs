using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiActivation : MonoBehaviour
{
    public GameObject FirstPage;
    public GameObject SecondPage;
    public GameObject ThirdPage;
    public float waitTime = 0.3f;

    public Animator SecondPageAnim;
    public Animator ThirdPageAnim;


    public void ActivateFirstPage(bool state)
    {
        StartCoroutine(FirstPageActivate(state));
    }

    IEnumerator FirstPageActivate(bool state)
    {
        yield return new WaitForSeconds(waitTime);
        FirstPage.SetActive(state);  
    }

    public void ActivateSecondPage(bool state)
    {
        StartCoroutine(SecondPageActivate(state));
    }

    IEnumerator SecondPageActivate(bool state)
    {
        yield return new WaitForSeconds(waitTime);
        SecondPage.SetActive(state);
        SecondPageAnim.SetTrigger("In");
    }

    public void ActivateThirdPage(bool state)
    {
        StartCoroutine(ThirdPageActivate(state));
    }

    IEnumerator ThirdPageActivate(bool state)
    {
        ThirdPageAnim.SetTrigger("In");
        yield return new WaitForSeconds(waitTime);
        ThirdPage.SetActive(state);
       
    }
}
