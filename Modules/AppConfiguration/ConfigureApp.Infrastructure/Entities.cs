using Core.Models;

namespace ConfigureApp.Infrastructure
{
    public class ApplicationModule: BaseEntity
    {
        public long ApplicationId { get { return Id; } set { Id = value; } }
        public string Name { get; set; }
        public ICollection<Form> Forms { get; set; }
    }
    public enum FormActions
    {
        Create, Update, Delete, BulkCreate, BulkUpdate, BulkDelete, GetById, GetAll
    }
    public class ActionApi: BaseEntity
    {
        public FormActions Action { get; set; }
        public string ApiURL { get; set; }
        public string ApiMethod { get; set; }
        public long FormId { get; set; }
        public Form ForForm { get; set; }
    }

    public class Form : BaseEntity
    {
        public long FormId { get { return Id; } set { Id = value; } }
        public string Title { get; set; }
        public string Name { get; set; }

        public ICollection<Field> Fields { get; set; }
        public ICollection<DisplayedColumn> DisplayedColumns { get; set; }
        public ICollection<ActionApi> ActionApis { get; set; }
        public long ApplicationId { get; set; }
        public ApplicationModule Application { get; set; }
    }

    public class Field : BaseEntity
    {
        public long FieldId { get { return Id; } set { Id = value; } }
        public string Name { get; set; }
        public string ToolTip { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public long FormId { get; set; }
        public Form Form { get; set; }
        public ICollection<Option> Options { get; set; }
    }

    public class Option : BaseEntity
    {
        public long OptionId { get { return Id; } set { Id = value; } }
        public string Label { get; set; }
        public string Value { get; set; }
        public long FieldId { get; set; }
        public Field Field { get; set; }
    }

    public class DisplayedColumn : BaseEntity
    {
        public long DisplayedColumnId { get { return Id; } set { Id = value; } }
        public string ColumnName { get; set; }
        public long FormId { get; set; }
        public Form Form { get; set; }
    }

}