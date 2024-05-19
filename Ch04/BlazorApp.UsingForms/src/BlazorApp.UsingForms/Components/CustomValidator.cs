using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.UsingForms.Components;

public abstract class CustomValidator<T> : ComponentBase
{
  [CascadingParameter]
  public required EditContext EditContext { get; set; }

  protected override void OnInitialized()
  {
    if (EditContext is null)
    {
      throw new InvalidOperationException("The CustomValidator needs to be nested in an EditForm");
    }

    ValidationMessageStore store = new(EditContext);

    EditContext.OnValidationRequested += (sender, e) =>
    {
      store?.Clear();
      foreach (string field in Fields)
      {
        Action<T, ValidationMessageStore> validator = GetFieldValidator(field);
        validator((T)EditContext.Model, store);
      }
    };

    EditContext.OnFieldChanged += (sender, e) =>
    {
      store?.Clear();
      Action<T, ValidationMessageStore> validator = GetFieldValidator(e.FieldIdentifier.FieldName);
      validator((T)EditContext.Model, store);
    };
  }

  protected abstract IEnumerable<string> Fields { get; }

  protected abstract Action<T, ValidationMessageStore> GetFieldValidator(string field);
}

