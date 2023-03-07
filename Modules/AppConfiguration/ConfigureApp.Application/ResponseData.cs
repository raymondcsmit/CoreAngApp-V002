namespace ConfigureApp.Application
{
    using System.Collections.Generic;
    using System.Linq;
    using ConfigureApp.Infrastructure;
    using Newtonsoft.Json;

    public class ApplicationResponse
    {
        [JsonProperty("Application")]
        public string Name { get; set; }

        [JsonProperty("forms")]
        public List<FormResponse> Forms { get; set; }
    }

    public class FormResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayedColumns")]
        public List<string> DisplayedColumns { get; set; }

        [JsonProperty("fields")]
        public List<FieldResponse> Fields { get; set; }
    }

    public class FieldResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
        public List<OptionResponse> Options { get; set; } 
    }

    public class OptionResponse
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public static class ConfigResponse
    {

    
    public static string GenerateJsonResponse(ApplicationModule application)
    {
        var response = new ApplicationResponse
        {
            Name = application.Name,
            Forms = application.Forms.Select(form => new FormResponse
            {
                Title = form.Title,
                Name = form.Name,
                DisplayedColumns = form.DisplayedColumns.Select(col => col.ColumnName).ToList(),
                Fields = form.Fields.Select(field => new FieldResponse
                {
                    Name = field.Name,
                    Type = field.Type,
                    Label = field.Label,
                    Required = field.Required,
                    Options = (field.Type == "select" && field.Options != null)
                     ? field.Options.Select(option => new OptionResponse                       
                        {
                            Label = option.Label,
                            Value = option.Value
                        }).ToList()
                        : null
                }).ToList()
            }).ToList()
        };

        return JsonConvert.SerializeObject(response);
    }
    }
}