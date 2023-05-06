using ConfigureApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureApp
{
    public static class DbInitializer
    {
        public static void Initialize(ConfigureAppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Applications.Any())
            {
                // DB has been seeded.
                return;
            }

            var application = new ApplicationModule
            {
                Name = "My Application",
                Forms = new Form[]
                {
                new Form
                {
                    Title = "My Form",
                    Name = "myform",
                    Fields = new Field[]
                    {
                        new Field
                        {
                            Name = "field1",
                            Type = "text",
                            Label = "Field 1",
                            Required = true,
                            Options = new Option[] { }
                        },
                        new Field
                        {
                            Name = "field2",
                            Type = "textarea",
                            Label = "Field 2",
                            Required = false,
                            Options = new Option[] { }
                        },
                        new Field
                        {
                            Name = "field3",
                            Type = "select",
                            Label = "Field 3",
                            Required = true,
                            Options = new Option[]
                            {
                                new Option { Label = "Option 1", Value = "1" },
                                new Option { Label = "Option 2", Value = "2" },
                                new Option { Label = "Option 3", Value = "3" }
                            }
                        }
                    },
                    DisplayedColumns = new DisplayedColumn[]
                    {
                        new DisplayedColumn { ColumnName = "field1" },
                        new DisplayedColumn { ColumnName = "field2" },
                        new DisplayedColumn { ColumnName = "field3" },
                    }
                }
                }
            };

            context.Applications.Add(application);
            context.SaveChanges();
        }
    }
}
