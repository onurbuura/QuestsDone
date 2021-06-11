using System.Collections;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{
    /// <summary>
    /// Check TODO Instructions inside of the Test1 folder
    /// </summary>
    public UnityEngine.UI.Text displayTxt;
    const string Fizz = "Fizz";
    const string Buzz = "Buzz";
    const string Fizzbuzz = "FizzBuzz";
    int val = 0;
    float counter = 0;

    [SerializeField] float endTime;
    [SerializeField] int maxLimit = 100;



    IEnumerator Start() //Start fonksiyonunu coroutine olarak çağırabiliyoruz.
    {
        WaitForSeconds wait = new WaitForSeconds(endTime / maxLimit);
        while (val < maxLimit)
        {
            SetText();
            yield return wait;
        }
    }

    //void Update()
    //{
    //    counter += Time.deltaTime;                                // counter değerinin işlem bittikten sonra artmaması gereksiz.
    //                                                              // 
    //    if (counter >= 0.2f)                                      // Gereksiz Update çağırımı Coroutine kullanılarak yapılması tercih edilir.
    //        SetText();                                            // 
    //}


    void SetText()
    {
        counter = 0f;
        val++;
        if (val <= maxLimit)
        {
            string msg = "";
            msg += (val % 3) == 0 ? "<color=blue>fizz</color>" : "";
            msg += (val % 5) == 0 ? "<color=red>buzz</color>" : "";
            displayTxt.text = (msg != string.Empty ? msg : val.ToString());

        }
    }
}
