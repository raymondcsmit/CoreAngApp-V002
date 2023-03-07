namespace ConfigureApp.Application
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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


        public static string SerializeConfigurationApp(ApplicationModule application)
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



        public static ApplicationModule DeSerializeConfigurationApp(string jsonString)
        {
            var obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            var applicationName = obj["Application"].ToString();

            var forms = obj["forms"] as List<object>;

            var application = new ApplicationModule
            {
                Name = applicationName,
                Forms = new List<Form>()
            };

            foreach (var formObj in forms)
            {
                var formDict = (Dictionary<string, object>)formObj;

                var formTitle = formDict["title"].ToString();
                var formName = formDict["name"].ToString();
                var displayedColumns = formDict["displayedColumns"] as List<object>;

                var fields = ((List<object>)formDict["fields"]).Select(f =>
                {
                    var fieldDict = (Dictionary<string, object>)f;

                    var field = new Field
                    {
                        Name = fieldDict["name"].ToString(),
                        Type = fieldDict["type"].ToString(),
                        Label = fieldDict["label"].ToString(),
                        Required = bool.Parse(fieldDict["required"].ToString()),
                        Options = new List<Option>()
                    };

                    if (fieldDict.ContainsKey("options"))
                    {
                        var options = (List<object>)fieldDict["options"];
                        field.Options = options.Select(o =>
                        {
                            var optionDict = (Dictionary<string, object>)o;
                            return new Option
                            {
                                Label = optionDict["label"].ToString(),
                                Value = optionDict["value"].ToString()
                            };
                        }).ToList();
                    }

                    return field;
                }).ToList();

                var form = new Form
                {
                    Title = formTitle,
                    Name = formName,
                    DisplayedColumns = displayedColumns.Select(c => new DisplayedColumn { ColumnName = c.ToString() }).ToList(),
                    Fields = fields
                };

                application.Forms.Add(form);
            }

            return application;
        }

    }
}