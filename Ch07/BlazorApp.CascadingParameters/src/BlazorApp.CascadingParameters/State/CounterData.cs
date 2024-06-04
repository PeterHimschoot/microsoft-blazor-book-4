namespace BlazorApp.CascadingParameters.State;

public class CounterData
{ // Or use INotifyPropertyChanged interface
  private int count;
  public int Count
  {
    get => this.count;
    set
    {
      if (value != this.count)
      {
        this.count = value;
        CountChanged?.Invoke(this.count);
      }
    }
  }
  public Action<int>? CountChanged { get; set; }
}
