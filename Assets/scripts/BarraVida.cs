using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraVida : MonoBehaviour {

	public  Scrollbar HealthBar;
	public float Health = 100;
    private void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "VidaBoss");
    }
    public void Damage(float value)
	{
		Health -= value;
		HealthBar.size = Health / 100f;
	}
    public void VidaBoss(Notification data)
    {
        Health -= (int)data.data;
        HealthBar.size = Health / 100f;
    }
}
