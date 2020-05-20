﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuthJanitor.Automation.Shared.ViewModels
{
    public class ProviderConfigurationItemViewModel : IAuthJanitorViewModel
    {
        public enum InputTypes
        {
            Text,
            TextArray,
            Integer,
            Boolean,
            Enumeration
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public InputTypes InputType { get; set; }
        public string HelpText { get; set; }
        public string Value { get; set; }
        public IEnumerable<SelectOption> Options { get; set; } = new List<SelectOption>();

        [JsonIgnore]
        public bool BoolValue
        {
            get
            {
                bool.TryParse(Value, out bool boolResult);
                return boolResult;
            }
            set => Value = value.ToString();
        }

        [JsonIgnore]
        public int IntValue
        {
            get
            {
                int.TryParse(Value, out int intResult);
                return intResult;
            }
            set => Value = value.ToString();
        }

        public class SelectOption
        {
            public string Value { get; set; }
            public string DisplayName { get; set; }

            public SelectOption() { }

            public SelectOption(string value, string displayName)
            {
                Value = value;
                DisplayName = displayName;
            }
        }
    }
}
