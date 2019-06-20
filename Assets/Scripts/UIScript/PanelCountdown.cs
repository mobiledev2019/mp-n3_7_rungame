using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PanelCountdown : PageBase
{

    [SerializeField] private int timeCount;
    [SerializeField] private Image circle;
    [SerializeField] private Text txTime;

    public void ShowCount(int time =3)
    {
        Show();
        timeCount = time;
        txTime.text = timeCount.ToString();
        circle.fillAmount = 1;
        circle.DOFillAmount(0, timeCount-1);
        CountDown();
    }

    private void CountDown()
    {
        timeCount--;
        txTime.text = timeCount.ToString();
        if (timeCount < 0) {
            Hide();
            return;
        }
        DOVirtual.DelayedCall(1, CountDown);
        
    }

}
