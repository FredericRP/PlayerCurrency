using FredericRP.EventManagement;
using FredericRP.GenericSingleton;
using FredericRP.PersistentData;
using UnityEngine;

namespace FredericRP.PlayerCurrency
{
  public class PlayerCurrencyManager : Singleton<PlayerCurrencyManager>
  {
    [SerializeField]
    StringIntGameEvent CurrencyUpdateEvent;

    // TODO : create online currency management

    public virtual int GetCurrencyCount(string moneyId)
    {
      return PersistentDataSystem.Instance.GetSavedData<PlayerCurrencyData>().GetCount(moneyId);
    }

    public virtual int AddToCurrency(string moneyId, int count)
    {
      int result = PersistentDataSystem.Instance.GetSavedData<PlayerCurrencyData>().Add(moneyId, count);
      CurrencyUpdateEvent?.Raise<string, int>(moneyId, result);
      return result;
    }

    CurrencyConversion moneyConversion = null;

    /// <summary>
    /// Provides an easy method to convert using the MoneyConversion asset found in a Resources folder.
    /// </summary>
    /// <param name="amount">the amount of currency to convert</param>
    /// <param name="sourceCurrencyId">id of source currency</param>
    /// <param name="destCurrencyId">id of destination currency</param>
    /// <returns></returns>
    public virtual int GetConvertedCurrency(int amount, string sourceCurrencyId, string destCurrencyId)
    {
      if (moneyConversion = null)
        moneyConversion = Resources.Load<CurrencyConversion>("CurrencyConversion");
      if (moneyConversion = null)
      {
        Debug.LogError("Can not convert if no conversion data file exists. There should be a ResourceS/CurrencyConversion.asset somewhere.");
        return amount;
      }
      return moneyConversion.GetTargetCurrencyNumber(amount, sourceCurrencyId, destCurrencyId);
    }
  }
}