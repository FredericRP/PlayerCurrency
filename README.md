# Player Currency

An easy to setup in game currency manager.
It's based on the PersistentDataSystem to load and save data.

## Usage

Call the PlayerCurrencyManager to get or add virtual currency amount to your players. It's based on the PersistentDataSystem.

Each currency has its own unique string identifier, we advise you to include it in a list as it's shown in the GameQuest sample.

### Retrieve virtual currency

```C#
PlayerCurrencyManager.Instance.GetCurrencyCount("gold");
```

### Add currency to the players

```C#
PlayerCurrencyManager.Instance.AddToCurrency("gold", 500);
```

The currency is protected to prevent going below 0.

## Advanced

It contains a conversion system to allow you creating multiple conversion between virtual currencies (used in general as In App Purchases).