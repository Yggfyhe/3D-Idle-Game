using UnityEngine;
using System.Collections;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int CurrentCurrency { get; private set; } = 0;  
    public int MinGain { get; private set; } = 1;          
    public int MaxGain { get; private set; } = 10;         
    public float GainInterval { get; private set; } = 2f;  
    public int UpgradeLevel { get; private set; } = 1;     

    public GameObject floatingTextPrefab; 
    public Transform uiTransform;         

    private void Start()
    {
        StartCoroutine(GainCurrencyOverTime());
    }

    private IEnumerator GainCurrencyOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(GainInterval);

            int amount = Random.Range(MinGain, MaxGain + 1) * UpgradeLevel;
            CurrentCurrency += amount;
            UIManager.Instance.UpdateCurrencyUI(CurrentCurrency);

            ShowFloatingText(amount);
        }
    }

    private void ShowFloatingText(int amount)
    {
        if (floatingTextPrefab != null && uiTransform != null)
        {
            GameObject floatingText = Instantiate(floatingTextPrefab, uiTransform.position, Quaternion.identity, uiTransform);
            floatingText.GetComponent<TextMeshProUGUI>().text = $"+{amount}";
            Destroy(floatingText, 1f); 
        }
    }

    // 건물 업그레이드 추가
    public void UpgradeBuilding()
    {
        UpgradeLevel++;
        MinGain += 5;   
        MaxGain += 10;
    }
}
