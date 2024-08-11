﻿using System.Text.Json;

namespace BlazorApp.PizzaPlace.Shared;

public static class DebuggingExtensions
{
  private static readonly JsonSerializerOptions options =
    new()
    {
      WriteIndented = true
    };

  public static string ToJson(this object obj)
  => JsonSerializer.Serialize(obj, options);
}
