using System;

namespace PM
{
    public sealed class HeroAbilityService
    {
          public event Action<string> OnNameChanged;
          public event Action<int> OnValueChanged;
          
          public string Name { get; private set; }
          public int Value { get; private set; }

          public void ChangeName(string name)
          {
              Name = name;
              OnNameChanged?.Invoke(name);
          }

          public void ChangeValue(int value)
          {
              Value = value;
              OnValueChanged?.Invoke(value);
          }

          public void ResetValues()
          {
              Name = string.Empty;
              Value = 0;
          }
    }
}