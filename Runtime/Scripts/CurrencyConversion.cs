using FredericRP.StringDataList;
using System.Collections.Generic;
using UnityEngine;

namespace FredericRP.PlayerCurrency
{
  [CreateAssetMenu(menuName = "Money Conversion")]
  public class CurrencyConversion : ScriptableObject
  {
    [System.Serializable]
    public class CurrencyConversionData
    {
      [Tooltip("Currency to convert FROM")]
      [Select(PlayerCurrencyData.CurrencyList)]
      public string sourceCurrencyId;
      [Tooltip("Currency to convert TO")]
      [Select(PlayerCurrencyData.CurrencyList)]
      public string targetCurrencyId;
      [Tooltip("FROM x factor = TO")]
      public float factor;
      [Tooltip("This factor applies from this minimal value")]
      public int min = 0;
      [Tooltip("This factor applies up to this maximal value")]
      public int max = int.MaxValue;
    }

    public List<CurrencyConversionData> conversionList;

    /// <summary>
    /// Gets the resulting number for the target currency from source currency and source number
    /// </summary>
    /// <returns>The sourceNumber converted to the new currency.</returns>
    /// <param name="sourceAmount">Source amount</param>
    /// <param name="sourceCurrencyId">Source currency.</param>
    /// <param name="targetCurrencyId">Target currency.</param>
    public int GetTargetCurrencyNumber(int sourceAmount, string sourceCurrencyId, string targetCurrencyId)
    {
      CurrencyConversionData data = conversionList.Find(
        element =>
        element.sourceCurrencyId.Equals(sourceCurrencyId) && element.targetCurrencyId.Equals(targetCurrencyId)
        && sourceAmount >= element.min && sourceAmount <= element.max);

      if (data != null)
      {
        return (int)(sourceAmount * data.factor);
      }
      return sourceAmount;
    }
  }
}